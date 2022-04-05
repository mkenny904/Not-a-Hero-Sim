using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl : MonoBehaviour
{
    public int money;
    public int healthpotion;
    public int staminapotion;
    public int manapotion;
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

    public int GetMaterial(int type)
    {
        switch (type)
        {
            case 2:
                return mana;
            case 3:
                return redflower;
            case 4:
                return greenflower;
            case 5:
                return blueflower;
        }
        return 0;
    }

    public void UseMaterial(int type)
    {
        switch (type)
        {
            case 2:
                mana--;
                break;
            case 3:
                redflower--;
                break;
            case 4:
                greenflower--;
                break;
            case 5:
                blueflower--;
                break;
        }
    }

    //Adds materials and money
    public void Add(int type, int cost = 0, int product = 0)
    {
        switch (type)
        {
            case 1:
                if(Sell(product))
                {
                    money += cost;
                }
                break;
            case 2:
                mana++;
                break;
            case 3:
                redflower++;
                break;
            case 4:
                greenflower++;
                break;
            case 5:
                blueflower++;
                break;
            case 6:
                healthpotion++;
                break;
            case 7:
                staminapotion++;
                break;
            case 8:
                manapotion++;
                break;
        }

    }

    //Checks if enough materials to sell
    public bool Sell(int type)
    {
        switch (type)
        {
            case 6:
                if(healthpotion >= 1)
                {
                    return true;
                }
                break;
            case 7:
                if(staminapotion >= 1)
                {
                    return true;
                }
                break;
            case 8:
                if(manapotion >= 1)
                {
                    return true;
                }
                break;
            
        }
        return false;
    }


    public enum material
    {
        mana = 2
    }
    public enum guildmaterial
    {
        redflower = 3,
        greenflower = 4,
        blueflower = 5
    }
    public enum product
    {
        healthpotion = 6, 
        staminapotion = 7,
        manapotion = 8
    }
}
