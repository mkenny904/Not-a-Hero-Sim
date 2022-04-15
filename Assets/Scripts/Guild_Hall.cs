using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guild_Hall : MonoBehaviour 
{
    bool infinite = true;
    public int buy_price;
    [SerializeField] SceneControl control;
    public int upgrade_level = 1;
    public int adventurer = 1;
    public float quest_speed = 10;
    public int upgrade_cost;
    public int upgrade_cost_increase;
    public int wages;
    public SceneControl.guildmaterial materialtype;
    
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
            adventurer = 2;
            quest_speed = 8;
        }else if(upgrade_level == 2 && control.Buy(upgrade_cost))
        {
            upgrade_level = 3;
            adventurer = 3;
            quest_speed = 5;
        }
    }

    private IEnumerator Timer()
    {
        float duration = quest_speed;
        float totalTime = 0;
        if(control.Buy(wages))
        { 
            while(totalTime <= duration)
            {
                totalTime += Time.deltaTime;
                //To assign timer visually
                //var integer = (int)totalTime;
                yield return null;
            }
            for(int i = 0; i < adventurer; i++)
            {
                control.Add(((int)materialtype));
            }
            
        }
        
        if(infinite == true)
        {
            StartCoroutine("Timer");
        }
    }

    public void ToggleAdventure()
    {
        if(infinite == false)
        {
            infinite = true;
            StartCoroutine("Timer");
        }
        else if(infinite == true)
        {
            infinite = false;
        }
    }

    public void ChangeQuest(int material)
    {
        materialtype = (SceneControl.guildmaterial)material;
        print(materialtype);
    }
}
