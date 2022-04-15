using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    bool infinite = true;
    public int buy_price;
    [SerializeField] SceneControl control;
    public int upgrade_level = 1;
    public int production = 1;
    public float production_time = 0;
    public int upgrade_cost;
    public int upgrade_cost_increase;
    public SceneControl.product producttype;
    public SceneControl.material material1;
    public SceneControl.guildmaterial material2;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Timer");
    }


    public void BuyUpgrade()
    {
        if(upgrade_level == 1 && control.Buy(upgrade_cost))
        {
            upgrade_cost += upgrade_cost_increase;
            upgrade_level = 2;
            production = 2;
            production_time = 8;
        }else if(upgrade_level == 2 && control.Buy(upgrade_cost))
        {
            upgrade_level = 3;
            production = 3;
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
