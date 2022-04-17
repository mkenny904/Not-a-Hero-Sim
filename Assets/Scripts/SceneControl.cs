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
    public int potion_price = 2;
    public int mana = 0;
    public int redflower = 0;
    public int greenflower = 0;
    public int blueflower = 0;
    public int building_price = 10;
    public int upgrade_price = 20;
    public int upgrade_2_price = 40;

    void Start()
    {

    }

    public void BuyUpgrade(ref int upgrade_level, ref int speed, ref int amount)
    {
        if(upgrade_level == 1 && money >= upgrade_price)
        {
            upgrade_level = 2;
            money -= upgrade_price;
            speed = 10;
            amount = 10;
        }
        else if(upgrade_level == 2 && money >= upgrade_2_price)
        {
            upgrade_level = 3;
            money -= upgrade_2_price;
            speed = 5;
            amount = 15;
        }
    }

    public bool Buy(int cost)
    {
        if(money >= cost)
        {
            money -= cost;
            return true;
        }
        return false;
    }

    public bool BuyBuilding()
    {
        if(money >= building_price)
        {
            money -= building_price;
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
        int i = 0;
        if(healthpotion >= 1)
        {
            healthpotion--;
            i++;
        }
        if(staminapotion >= 1)
        {
            staminapotion--;
            i++;
        }
        if(manapotion >= 1)
        {
            manapotion--;
            i++;
        }
        money += (potion_price * i);
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
