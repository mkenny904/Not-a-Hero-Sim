using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    // Set to products in the scene
    public Product potion;
    public Product sword;
    // For a modified Observer Design Patter
    private List<Product> products = new List<Product>();
    public double money = 100;
    private int potion_ingredient1 = 1;
    private int potion_ingredient2 = 1;
    public double potiontimer = 0;
    double swordtimer = 0;
    void Start()
    {
        // No save-game yet but this is for that
        if(potion.is_active){
            products.Add(potion);
        }
        if(sword.is_active){
            products.Add(sword);
        }
    }

    void Update()
    {
        Timer();
    }

    public void Timer()
    {
        potiontimer += Time.deltaTime;
        swordtimer += Time.deltaTime;
        if(potiontimer >= potion.production_time)
        {
            money += potion.Sell();
            potiontimer = 0;
        }
        if(swordtimer >= sword.production_time)
        {
            money += sword.Sell();
            swordtimer = 0;
        }
    }

    public void Sell(){
        foreach (Product product in products)
        {
            // This doesn't work
            //if(product.production_time % timer == 0){
            money += product.Sell();
            //}
        }
    }

    // For buying shops
    public void BuyShop(Product product){
        if(!product.is_active && money >= product.shopcost){
            product.BuyShop();
            products.Add(product);
            money -= product.shopcost;
        }
    }

    public void BuyUpgrade(Product product){
        if(money >= product.upgrade_cost){
            money -= product.upgrade_cost;
            product.BuyPriceUpgrade();
        }
    }
    public void BuySellerUpgrade(Product product){
        if(money >= product.seller_upgrade_cost){
            money -= product.seller_upgrade_cost;
            product.BuySellerUpgrade();
        }
    }
    public void BuySeller(Product product){
        if(money >= product.seller_cost){
            money -= product.seller_upgrade_cost;
            product.BuySeller();
        }
    }
}
