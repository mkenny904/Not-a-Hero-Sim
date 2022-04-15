using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    bool infinite = true;
    public int buy_price;
    [SerializeField] SceneControl control;
    public int upgrade_level = 1;
    public int sell_volume = 1;
    public int sell_time = 10;
    public int upgrade_cost;
    public int upgrade_cost_increase;
    
    // Start is called before the first frame update
    void Start()
    {

    }


    public void BuyUpgrade()
    {
        if(upgrade_level == 1 && control.Buy(upgrade_cost))
        {
            upgrade_cost += upgrade_cost_increase;
            upgrade_level = 2;
            sell_volume = 2;
            sell_time = 8;
        }else if(upgrade_level == 2 && control.Buy(upgrade_cost))
        {
            upgrade_level = 3;
            sell_volume = 3;
            sell_time = 5;
        }
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
