using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildButtons : MonoBehaviour
{
    public GameObject healthBuilding;
    public GameObject manaBuilding;
    public GameObject staminaBuilding;
    public GameObject crackedManaStone;
    public GameObject questhall;
    public GameObject merchant;
    public int cost = 10;
    public int debtlimit = 0;

    public GameObject upgradeHB_Button;
    public int HBlevel = 1;
    public GameObject upgradeMB_Button;
    public int MBlevel = 1;
    public GameObject upgradeSB_Button;
    public int SBlevel = 1;
    public GameObject upgradeCrystal_Button;
    public int Clevel = 1;
    public GameObject upgradeMerchant_Button;
    public int Mlevel = 1;

    public void BuildHealthBuilding(){
        if(cost <= GameManager.Gold && !healthBuilding.activeSelf){
            healthBuilding.SetActive(true); 
            GameManager.Gold -= cost;
            StartCoroutine(makeHealthPot());
        }
    }

    public void BuildManaBuilding(){
        if(cost <= GameManager.Gold && !manaBuilding.activeSelf){
            manaBuilding.SetActive(true);
            GameManager.Gold -= cost;
            StartCoroutine(makeManaPot());
        }
    }

    public void BuildStaminaBuilding(){
        if(cost <= GameManager.Gold && !staminaBuilding.activeSelf){
            staminaBuilding.SetActive(true);
            GameManager.Gold -= cost;
            StartCoroutine(makeStaminaPot());
        }
    }

    public void BuildCrackedManaStone(){
         if(cost <= GameManager.Gold && !crackedManaStone.activeSelf){
             crackedManaStone.SetActive(true);
             GameManager.Gold -= cost;
            StartCoroutine(makeMana());
        }
    }

    public void BuildQuesthall(){
        if(cost <= GameManager.Gold && !merchant.activeSelf){
            questhall.SetActive(true);
            GameManager.Gold -= cost;
            StartCoroutine(FetchQuest());
        }
    }
    public void BuildMerchant(){
        if(cost <= GameManager.Gold && !merchant.activeSelf){
            merchant.SetActive(true);
            GameManager.Gold -= cost;
            StartCoroutine(SellGoods());
        }
    }

    //upgrade the buildings.
    public void UpgradeHB() 
    {
        GameManager.Gold = GameManager.Gold - 50 * HBlevel;
        HBlevel = HBlevel + 1;
        
    }
    public void UpgradeMB()
    {
        GameManager.Gold = GameManager.Gold - 50 * MBlevel;
        MBlevel = MBlevel + 1;
    }
    public void UpgradeSB()
    {
        GameManager.Gold = GameManager.Gold - 50 * SBlevel;
        SBlevel = SBlevel + 1;
    }
    public void UpgradeCrystal()
    {
        GameManager.Gold = GameManager.Gold - 50 * Clevel;
        Clevel = Clevel + 1;
    }
    public void UpgradeMerchant()
    {
        GameManager.Gold = GameManager.Gold - 50 * Mlevel;
        Mlevel = Mlevel + 1;
    }

    //Gather resources
    public IEnumerator makeHealthPot()
    {
        yield return new WaitForSeconds(5);
        GameManager.Heatlh_Potion = GameManager.Heatlh_Potion + 5 * HBlevel;
        GameManager.Red_Flower = GameManager.Red_Flower - 2;
        GameManager.Mana = GameManager.Mana - 1;
        StartCoroutine(makeHealthPot());
    }

    public IEnumerator makeManaPot()
    {
        yield return new WaitForSeconds(5);
        GameManager.Mana_Potion = GameManager.Mana_Potion + 5 * MBlevel;
        GameManager.Blue_Flower = GameManager.Blue_Flower - 2;
        GameManager.Mana = GameManager.Mana - 1;
        StartCoroutine(makeManaPot());
    }
    public IEnumerator makeStaminaPot()
    {
        yield return new WaitForSeconds(5);
        GameManager.Stamina_Potion = GameManager.Stamina_Potion + 5 * SBlevel;
        GameManager.Green_Flower = GameManager.Green_Flower - 2;
        GameManager.Mana = GameManager.Mana - 1;
        StartCoroutine(makeStaminaPot());
    }

    public IEnumerator makeMana()
    {
        yield return new WaitForSeconds(5);
        GameManager.Mana = GameManager.Mana + 5 * Clevel;
        StartCoroutine(makeMana());
    }
    public IEnumerator FetchQuest()
    {
        yield return new WaitForSeconds(5);
        GameManager.Gold -= cost;
        GameManager.Red_Flower = GameManager.Red_Flower + 5;
        GameManager.Blue_Flower = GameManager.Blue_Flower + 5;
        GameManager.Green_Flower = GameManager.Green_Flower + 5;
        StartCoroutine(FetchQuest());
    }

    public IEnumerator SellGoods()
    {
        yield return new WaitForSeconds(5);
        if (healthBuilding.activeSelf is true)
        {
            GameManager.Heatlh_Potion = GameManager.Heatlh_Potion - 3 * MBlevel;
            GameManager.Gold = GameManager.Gold + 8 * MBlevel;
        }
        if (manaBuilding.activeSelf is true)
        {
            GameManager.Mana_Potion = GameManager.Mana_Potion - 3 * MBlevel;
            GameManager.Gold = GameManager.Gold + 8 * MBlevel;
        }
        if (staminaBuilding.activeSelf is true) 
        {
            GameManager.Stamina_Potion = GameManager.Stamina_Potion - 3 * MBlevel;
            GameManager.Gold = GameManager.Gold + 8 * MBlevel; 
        }

        StartCoroutine(SellGoods());
    }




}





