using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    public int upgrade_cost;
    public int production_time_upgrade_level {get; private set;}
    public int production_upgrade_level {get; private set;}
    public int number_of {get; private set;}
    public int production {get; private set;}
    public int material1;
    public int material2;
    public float production_time;
    // Start is called before the first frame update
    void Start()
    {
        material1 = 0;
        material2 = 0;
        number_of = 0;
        production = 1;
        production_time = 10;
        production_upgrade_level = 1;
        production_time_upgrade_level = 1;
        StartCoroutine("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public double GetProduct(){
        if(number_of<1)
        {
            return 0;
        }
        number_of -= 1;
        return 1;
    }

    public void BuyProductionUpgrade(double money)
    {
        if(production_upgrade_level == 1)
        {
            production_upgrade_level = 2;
            production = 2;
        }else if(production_upgrade_level == 2)
        {
            production_upgrade_level = 3;
            production = 3;
        }
    }

    public void BuyProductionTimeUpgrade(double money)
    {
        if(production_time_upgrade_level == 1)
        {
            production_time_upgrade_level = 2;
            production_time = 8;
        }else if(production_time_upgrade_level == 2)
        {
            production_time_upgrade_level = 3;
            production_time = 5;
        }
    }

    private IEnumerator Timer()
    {
      float duration = production_time;
      float totalTime = 0;
      if(material1>0 && material2>0)
      {
          material1--;
          material2--;
        while(totalTime <= duration)
        {
            totalTime += Time.deltaTime;
            //To assign timer visually
            //var integer = (int)totalTime;
            yield return null;
        }
        number_of += production;
      }
    }

}
