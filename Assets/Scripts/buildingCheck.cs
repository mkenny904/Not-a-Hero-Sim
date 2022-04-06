using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingCheck : MonoBehaviour
{







    void Start()
    {
        if (gameObject.name.Contains("Health Building"))
        {
            StartCoroutine(makeHealthPot());
        }
    }

    public IEnumerator makeHealthPot()
    {
        yield return new WaitForSeconds(5);
        GameManager.Heatlh_Potion = GameManager.Heatlh_Potion + 5;
        StartCoroutine(makeHealthPot());
    }
}
