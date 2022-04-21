using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    bool infinite = true;
    [SerializeField] SceneControl control;
    public int upgrade_level = 1;
    public int production = 5;
    public int production_time = 15;
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
        control.BuyUpgrade(ref upgrade_level, ref production_time, ref production);
    }

    public void LoadUpgrade(int upgrade)
    {
        control.LoadUpgrade(upgrade, ref upgrade_level, ref production_time, ref production);
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
