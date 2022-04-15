using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : MonoBehaviour
{
    bool infinite = true;
    public int buy_price;
    [SerializeField] SceneControl control;
    
    public int upgrade_level = 1;
    public int production = 1;
    public float production_time = 10;
    public int upgrade_cost;
    public int upgrade_cost_increase;
    public SceneControl.material materialtype;
    public Sprite sprite2;
    public Sprite sprite3;
    
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
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;
        }else if(upgrade_level == 2 && control.Buy(upgrade_cost))
        {
            upgrade_level = 3;
            production = 3;
            production_time = 5;
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite3;
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
            control.Add(((int)materialtype));
        }
    }
}
