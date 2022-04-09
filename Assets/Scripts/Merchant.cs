using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    private bool infinite = true;
    public int cost;
    public SceneControl.product producttype;
    [SerializeField] SceneControl control;
    public int sell_time_upgrade_level {get; private set;}
    public int sell_volume_upgrade_level {get; private set;}
    public int sell_volume {get; private set;}
    public float sell_time;
    public int buy_price;
    // Start is called before the first frame update
    void Start()
    {
        sell_time_upgrade_level = 1;
        sell_volume_upgrade_level = 1;
        sell_time = 10;
        sell_volume = 2;
        StartCoroutine("Timer");
    }


    public void BuySellTimeUpgrade()
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

    public void BuySellVolumeUpgrade()
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
        while(infinite == true)
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
            Sell();
        }
    }

    public void Sell()
    {
        for(int i = 0; i < sell_volume; i++)
        {
            if(control.Sell(((int)producttype)))
            {
            
                control.Add(1, cost);
            }
        }
    }

}
