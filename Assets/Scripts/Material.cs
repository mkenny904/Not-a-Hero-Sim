using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : MonoBehaviour
{
    public int production_time_upgrade_level {get; private set;}
    public int production_upgrade_level {get; private set;}
    public int number_of {get; private set;}
    public int production {get; private set;}
    public float production_time;
    public int material;
    SceneControl control;
    void Start()
    {
        print("starting");
        control = GameObject.Find("SceneControl").GetComponent<SceneControl>();
        material = control.blueflower;
        number_of = 0;
        production = 1;
        production_time = 10;
        production_upgrade_level = 1;
        production_time_upgrade_level = 1;
        StartCoroutine("Timer");
        print("finished");
    }

    // Update is called once per frame
    void Update()
    {
        
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
        bool infinite = true;
        while(infinite==true)
        {
            float duration = production_time;
            float totalTime = 0;
            while(totalTime <= duration)
            {
                totalTime += Time.deltaTime;
                //To assign timer visually
                //var integer = (int)totalTime;
                yield return null;
            }
            material += production;
            print(control.blueflower);
        }
    }
}
