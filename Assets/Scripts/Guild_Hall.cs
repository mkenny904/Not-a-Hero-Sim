using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guild_Hall : MonoBehaviour 
{
    bool infinite = true;
    [SerializeField] SceneControl control;
    public int upgrade_level = 1;
    public int adventurer = 5;
    public int quest_speed = 15;
    public int wages = 5;
    public SceneControl.guildmaterial materialtype;
    
    void Start()
    {
        StartCoroutine("Timer");
    }

    public void BuyUpgrade()
    {
        control.BuyUpgrade(ref upgrade_level, ref quest_speed, ref adventurer);
    }

    public void LoadUpgrade(int upgrade)
    {
        control.LoadUpgrade(upgrade, ref upgrade_level, ref quest_speed, ref adventurer);
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
    }
}
