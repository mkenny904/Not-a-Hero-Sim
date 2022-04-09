using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl : MonoBehaviour
{
    //Holds amounts of everything and has some methods multiple classes use
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
       healthpotion = 0;
       staminapotion = 0;
       manapotion = 0;
       redflower = 0;
       greenflower = 0; 
       blueflower = 0;
    }

    public bool Buy(int price)
    {
        if(money >= price)
        {
            money -= price;
            return true;
        }
        return false;
    }

    public bool GetMaterial(int type)
    {
        switch (type)
        {
            case 2:
                if(mana > 0)
                {
                    return true;
                }
                break;
            case 3:
                if(redflower > 0)
                {
                    return true;
                }
                break;
            case 4:
                if(greenflower > 0)
                {
                    return true;
                }
                break;
            case 5:
                if(blueflower > 0)
                {
                    return true;
                }
                break;
        }
        return false;
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
    public void Add(int type, int cost = 0)
    {
        switch (type)
        {
            case 1:
                money += cost;
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
                    healthpotion--;
                    return true;
                }
                break;
            case 7:
                if(staminapotion >= 1)
                {
                    staminapotion--;
                    return true;
                }
                break;
            case 8:
                if(manapotion >= 1)
                {
                    manapotion--;
                    return true;
                }
                break;
            
        }
        return false;
    }

    public bool Upgrade(int cost)
    {
        if(money >= cost)
        {
            return true;
        }
        return false;
    }

    //Add new enums for new materials and products
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
