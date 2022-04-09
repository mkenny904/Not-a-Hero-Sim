using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // This is the game logic. 
    //First, this is the resources to be used in the game

    //cost of buildings
    public int building_cost = 10;
    //These are the flowers for the creation of the potions and for the fetch quests out of the quest hall.
    public Text redflower_Display;
    public Text blueflower_Display;
    public Text greenflower_Display;
    //Mana is collected from the mana stone.
    public Text mana_Display;

    //Potions that are created.
    public Text healthPot_Display;
    public Text manaPot_Display;
    public Text staminaPot_Display;
    //In order to pay for fetch quests and to buy buildings, gold is used.
    public Text gold_Display;
    [SerializeField] SceneControl control;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        //Control to display the resources to the play screen.
        //Flowers
        redflower_Display.text = control.redflower.ToString();
        blueflower_Display.text = control.blueflower.ToString();
        greenflower_Display.text = control.greenflower.ToString();
        //Mana
        mana_Display.text = control.mana.ToString();
        //Potions
        healthPot_Display.text = control.healthpotion.ToString();
        manaPot_Display.text = control.manapotion.ToString();
        staminaPot_Display.text = control.staminapotion.ToString();
        //Money
        gold_Display.text = control.money.ToString();
       
    }

    public void BuyBuilding(GameObject building)
    {
        if(control.money >= building_cost && !building.activeInHierarchy)
        {
            control.money -= building_cost;
            building.SetActive(true);
        }
    }
}