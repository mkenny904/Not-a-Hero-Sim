using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    bool infinite = true;
    public SceneControl.product producttype;
    public SceneControl.material material1;
    public SceneControl.guildmaterial material2;
    [SerializeField] SceneControl control;
    public int production_time_upgrade_level {get; private set;}
    public int production_upgrade_level {get; private set;}
    public int production {get; private set;}
    public float production_time;
    public int buy_price;
    // Start is called before the first frame update
    void Start()
    {
        production = 1;
        production_time = 10;
        production_upgrade_level = 1;
        production_time_upgrade_level = 1;
        StartCoroutine("Timer");
    }


    public void BuyProductionUpgrade()
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

    public void BuyProductionTimeUpgrade()
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
            Produce();
        }
    }

    private void Produce()
    {
        for(int i = 0; i < production; i++)
        {
            if(control.GetMaterial(((int)material1)) && control.GetMaterial(((int)material2)))
            {
                control.UseMaterial(((int)material1));
                control.UseMaterial(((int)material2));
                control.Add(((int)producttype));
            }
        }
    }

}
