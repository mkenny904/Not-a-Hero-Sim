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
    public int speed_upgrade_cost;
    public int adventurer_upgrade_cost;
    //What the next upgrade is multiplied by
    public int upgrade_multiplier = 3;
    public int buy_price;
    //Chance 1 == 100 like .25 == 25% chance to lose
    private double quest_chance = .1;
    private Quest quest_type = Quest.easy;
    [SerializeField] SceneControl control;
    void Start()
    {
        adventurer = 1;
        adventure_speed = 10;
        adventurer_upgrade_level = 1;
        adventure_speed_upgrade_level = 1;
        StartCoroutine("Timer");
    }

    public void BuyAdventureUpgrade()
    {
        if(adventurer_upgrade_level == 1)
        {
            if(control.Upgrade(adventurer_upgrade_cost))
            {
                adventurer_upgrade_level = 2;
                adventurer = 2;
                adventurer_upgrade_cost *= upgrade_multiplier;
            }
        }else if(adventurer_upgrade_level == 2)
        {
            if(control.Upgrade(adventurer_upgrade_cost))
            {
                adventurer_upgrade_level = 3;
                adventurer = 3;
            }
        }
    }

    public void BuyAdventureSpeedUpgrade()
    {
        if(adventure_speed_upgrade_level == 1)
        {
            if(control.Upgrade(speed_upgrade_cost))
            {
                adventure_speed_upgrade_level = 2;
                adventure_speed = 8;
                speed_upgrade_cost *= upgrade_multiplier;
            }
        }else if(adventure_speed_upgrade_level == 2)
        {
            if(control.Upgrade(speed_upgrade_cost))
            {
                adventure_speed_upgrade_level = 3;
                adventure_speed = 5;
            }
        }
    }

    private IEnumerator Timer()
    {
        while(infinite==true)
        {
            float duration = adventure_speed;
            float totalTime = 0;
            if(control.money >= wages)
            { 
                control.money -= wages;
                while(totalTime <= duration)
                {
                    totalTime += Time.deltaTime;
                    //To assign timer visually
                    //var integer = (int)totalTime;
                    yield return null;
                }
                if(!(Random.value < quest_chance))
                {
                    for(int i = 0; i < adventurer*((int)quest_type); i++)
                    {
                        control.Add(((int)materialtype));
                    }
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

    public void ChangeQuest(int quest)
    {
        switch (quest)
        {
            case 1:
                quest_type = (Quest)quest;
                quest_chance = .05;
                break;
            case 2:
                quest_type = (Quest)quest;
                quest_chance = .15;
                break;
            case 3:
                quest_type = (Quest)quest;
                quest_chance = .25;
                break;
            case 4:
                quest_type = (Quest)quest;
                quest_chance = .40;
                break;
        }
    }

    [SerializeField] public enum Quest
    {
        easy = 1, 
        medium = 2,
        hard = 3,
        extreme = 4
    }
}
