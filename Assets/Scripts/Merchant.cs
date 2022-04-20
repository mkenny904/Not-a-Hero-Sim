using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    bool infinite = true;
    [SerializeField] SceneControl control;
    public int upgrade_level = 1;
    public int sell_volume = 5;
    public int sell_time = 15;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Timer");
    }


    public void BuyUpgrade()
    {
        control.BuyUpgrade(ref upgrade_level, ref sell_time, ref sell_volume);
    }
    public void LoadUpgrade(int upgrade)
    {
        control.LoadUpgrade(upgrade, ref upgrade_level, ref sell_time, ref sell_volume);
    }

    private IEnumerator Timer()
    {
        while(infinite == true)
        {
            while(control.Sellable())
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
                    control.Sell();
                }
            }
            yield return new WaitForSeconds(1);
        }
    }

}
