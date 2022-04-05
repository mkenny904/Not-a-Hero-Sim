using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guild_Hall : MonoBehaviour
{
    bool infinite = true;
    public SceneControl.guildmaterial materialtype;
    public int wages;
    public int adventure_speed_upgrade_level {get; private set;}
    public int adventurer_upgrade_level {get; private set;}
    public int adventurer {get; private set;}
    public float adventure_speed;
    SceneControl control;
    void Start()
    {
        control = GameObject.Find("SceneControl").GetComponent<SceneControl>();
        adventurer = 1;
        adventure_speed = 10;
        adventurer_upgrade_level = 1;
        adventure_speed_upgrade_level = 1;
        StartCoroutine("Timer");
    }


    public void BuyAdventureUpgrade(double money)
    {
        if(adventurer_upgrade_level == 1)
        {
            adventurer_upgrade_level = 2;
            adventurer = 2;
        }else if(adventurer_upgrade_level == 2)
        {
            adventurer_upgrade_level = 3;
            adventurer = 3;
        }
    }

    public void BuyAdventureTimeUpgrade(double money)
    {
        if(adventure_speed_upgrade_level == 1)
        {
            adventure_speed_upgrade_level = 2;
            adventure_speed = 8;
        }else if(adventure_speed_upgrade_level == 2)
        {
            adventure_speed_upgrade_level = 3;
            adventure_speed = 5;
        }
    }

    private IEnumerator Timer()
    {
        while(infinite==true)
        {
            float duration = adventure_speed;
            float totalTime = 0;
            while(totalTime <= duration)
            {
                totalTime += Time.deltaTime;
                //To assign timer visually
                //var integer = (int)totalTime;
                yield return null;
            }
            for(int i = 0; i < adventurer; i++)
                {
                    if(control.money >= wages)
                    {
                        control.Add(((int)materialtype));
                    }
                }
        }
    }

    public void ToggleAdventure()
    {
        if(infinite == false)
        {
            infinite = true;
        }
        else if(infinite == true)
        {
            infinite = false;
        }
    }
}
