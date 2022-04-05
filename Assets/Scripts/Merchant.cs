using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    private bool infinite = true;
    public int cost;

    //1 = health potion, 2 = stamina potion, 3 = mana potion
    public SceneControl.product producttype;
    SceneControl control;
    public int sell_time_upgrade_level {get; private set;}
    public int sell_volume_upgrade_level {get; private set;}
    public int sell_volume {get; private set;}
    public float sell_time;
    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.Find("SceneControl").GetComponent<SceneControl>();
        sell_time_upgrade_level = 1;
        sell_volume_upgrade_level = 1;
        sell_time = 10;
        sell_volume = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuySellTimeUpgrade(double money)
    {
        if(sell_time_upgrade_level == 1)
        {
            sell_time_upgrade_level = 2;
            sell_time = 2;
        }else if(sell_time_upgrade_level == 2)
        {
            sell_time_upgrade_level = 3;
            sell_time = 3;
        }
    }

    public void BuySellVolumeUpgrade(double money)
    {
        if(sell_volume_upgrade_level == 1)
        {
            sell_volume_upgrade_level = 2;
            sell_volume = 8;
        }else if(sell_volume_upgrade_level == 2)
        {
            sell_volume_upgrade_level = 3;
            sell_volume = 5;
        }
    }

    private IEnumerator Timer()
    {
        while(infinite==true)
        {
            if(control.Sell(((int)producttype)))
            {
                float duration = sell_time;
                float totalTime = 0;
                while(totalTime <= duration)
                {
                    totalTime += Time.deltaTime;
                    //To assign timer visually
                    //var integer = (int)totalTime;
                    yield return null;
                }
                for(int i = 0; i < sell_volume; i++)
                {
                    control.Add(1, cost, ((int)producttype));
                }
            }
        }
    }

}
