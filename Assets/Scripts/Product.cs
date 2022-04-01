using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    public int shopcost;
    public bool is_active {get; private set;}
    public int upgrade_multiplier {get; private set;}
    public int upgrade_cap {get; private set;}
    public int number_of {get; private set;}
    public int seller {get; private set;}
    public int seller_upgrade_level {get; private set;}
    public double seller_upgrade_multiplier {get; private set;}
    public int seller_upgrade_cap {get; private set;}
    public double cost;
    public int upgrade_level {get; private set;}
    public int seller_cost;
    public int seller_upgrade_cost;
    public int upgrade_cost;
    public double production_time {get; private set;}
    // Start is called before the first frame update
    void Start()
    {
        is_active = false;
        upgrade_multiplier = 2;
        upgrade_cap = 10;
        number_of = 20;
        seller = 0;
        seller_upgrade_level = 0;
        seller_upgrade_multiplier = .8;
        seller_upgrade_cap = 10;
        production_time = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyShop()
    {
        is_active = true;
    }


    public void BuySeller()
    {
        seller += 1;
        cost *= seller;
        seller_cost *= 10;

    }

    public double Sell(){
        if(number_of < seller)
        {
            return 0;
        }
        //no products are added right now so this just stops the code that's here
        //number_of -= seller;
        return seller * cost;
    }

    public void BuyPriceUpgrade()
    {
        upgrade_cost *= 2;
        cost *= 2;
        upgrade_level += 1;
        if(upgrade_level % upgrade_cap == 0)
        {
            upgrade_cap *= 2;
            cost *= upgrade_multiplier;
            upgrade_multiplier *= 2;
        }
    }

    public void BuySellerUpgrade()
    {
        seller_upgrade_cost *= 2;
        production_time *=  0.95;
        seller_upgrade_level += 1;
        if(seller_upgrade_level % seller_upgrade_cap == 0)
        {
            seller_upgrade_cap *= 2;
            production_time *= seller_upgrade_multiplier;
            seller_upgrade_multiplier *= 2;
        }
    }




}
