using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // This is the game logic. 
    //First, this is the resources to be used in the game

    //These are the flowers for the creation of the potions and for the fetch quests out of the quest hall.
    public static float Red_Flower;
    public Text redflower_Display;
    public static float Blue_Flower;
    public Text blueflower_Display;
    public static float Green_Flower;
    public Text greenflower_Display;
    //Mana is collected from the mana stone.
    public static float Mana;
    public Text mana_Display;

    //Potions that are created.
    public static float Heatlh_Potion;
    public Text healthPot_Display;
    public static float Mana_Potion;
    public Text manaPot_Display;
    public static float Stamina_Potion;
    public Text staminaPot_Display;
    //In order to pay for fetch quests and to buy buildings, gold is used.
    public static double Gold = 50;
    public Text gold_Display;



    // Update is called once per frame
    void Update()
    {
        
        //Control to display the resources to the play screen.
        //Flowers
        redflower_Display.text = Red_Flower.ToString();
        blueflower_Display.text = Blue_Flower.ToString();
        greenflower_Display.text = Green_Flower.ToString();
        //Mana
        mana_Display.text = Mana.ToString();
        //Potions
        healthPot_Display.text = Heatlh_Potion.ToString();
        manaPot_Display.text = Mana_Potion.ToString();
        staminaPot_Display.text = Stamina_Potion.ToString();
        //Gold
        gold_Display.text = Gold.ToString();
       
    }
}