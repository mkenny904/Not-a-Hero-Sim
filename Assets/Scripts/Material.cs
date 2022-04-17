using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : MonoBehaviour
{
    bool infinite = true;
    [SerializeField] SceneControl control;
    
    public int upgrade_level = 1;
    public int production = 5;
    public int production_time = 15;
    public SceneControl.material materialtype;
    public Sprite sprite2;
    public Sprite sprite3;
    
    void Start()
    {
        StartCoroutine("Timer");
    }

    public void BuyUpgrade()
    {
        control.BuyUpgrade(ref upgrade_level, ref production_time, ref production);
        if(upgrade_level == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;
        }
        if(upgrade_level == 3)
        {
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
            for(int i = 0; i < production; i++)
            {
                control.Add(((int)materialtype));
            }
        }
    }
}
