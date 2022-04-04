using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl : MonoBehaviour
{
    //Even though it's called scenecontrol, this just handles data
    int money;
    int healthpotion;
    int staminapotion;
    int manapotion;
    public int mana;
    public int redflower;
    public int greenflower;
    public int blueflower;

    void Start()
    {
       money = 0;
       healthpotion = 0;
       staminapotion = 0;
       manapotion = 0;
       redflower = 0;
       greenflower = 0; 
       blueflower = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
