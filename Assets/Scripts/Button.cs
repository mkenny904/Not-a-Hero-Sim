using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public TextMesh txt;
    public GameControl Control;
    public Product product;
    public Function function;
    private int cost;
    private int num;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if(function == Function.BuyShop){
            Control.BuyShop(product);
            txt.text = "Bought";
        }else if(function == Function.BuySeller){
            Control.BuySeller(product);
            cost = product.seller_cost;
            num = product.seller;
            txt.text = "Buy\nSeller\n" + num.ToString() + "\n$" + cost.ToString();
        }else if(function == Function.BuyUpgrade){
            Control.BuyUpgrade(product);
            cost = product.upgrade_cost;
            num = product.upgrade_level;
            txt.text = "Upgrade\n" + num.ToString() + "\n$" + cost.ToString();
        }else if(function == Function.BuySellerUpgrade){
            Control.BuySellerUpgrade(product);
            cost = product.seller_upgrade_cost;
            num = product.seller_upgrade_level;
            txt.text = "Seller\nUpgrade\n" + num.ToString() + "\n$" + cost.ToString();
        }
    }

    public enum Function
    {
        BuyShop,
        BuySeller,
        BuyUpgrade,
        BuySellerUpgrade
    }

}
