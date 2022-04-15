using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl : MonoBehaviour
{
    //Holds amounts of everything and has some methods multiple classes use
    public int money = 0;
    public int healthpotion = 0;
    public int staminapotion = 0;
    public int manapotion = 0;
    public int healthpotion_cost;
    public int staminapotion_cost;
    public int manapotion_cost;
    public int mana = 0;
    public int redflower = 0;
    public int greenflower = 0;
    public int blueflower = 0;

    void Start()
    {

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
    public void Sell()
    {
        if(healthpotion >= 1)
        {
            healthpotion--;
            Add(1, healthpotion_cost);
        }
        if(staminapotion >= 1)
        {
            staminapotion--;
            Add(1, staminapotion_cost);
        }
        if(manapotion >= 1)
        {
            manapotion--;
            Add(1, manapotion_cost);
        }
    }

    public bool Sellable()
    {
        if(healthpotion >= 1 || staminapotion >= 1 || manapotion >= 1)
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
