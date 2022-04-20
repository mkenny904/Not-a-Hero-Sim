using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public SceneControl control;
    public Material manacrystal;
    public Guild_Hall guild;
    public Product health;
    public Product stamina;
    public Product mana;
    public Merchant merchant;
    public GameManager manager;
    public GameObject manacrystal_building;
    public GameObject guild_building;
    public GameObject health_building;
    public GameObject stamina_building;
    public GameObject mana_building;
    public GameObject merchant_building;
    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter(); 
        FileStream file = File.Create(Application.persistentDataPath 
                    + "/SaveData.dat"); 
        SavedData data = new SavedData();
        data.manacrystal_lvl = manacrystal.upgrade_level;
        data.guild_lvl = guild.upgrade_level;
        data.health_lvl = health.upgrade_level;
        data.stamina_lvl = stamina.upgrade_level;
        data.mana_lvl = mana.upgrade_level;
        data.merchant_lvl = merchant.upgrade_level;
        data.money = control.money;
        data.healthpotion = control.healthpotion;
        data.staminapotion = control.staminapotion;
        data.manapotion = control.manapotion;
        data.mana = control.mana;
        data.redflower = control.redflower;
        data.greenflower = control.greenflower;
        data.blueflower = control.blueflower;
        data.manacrystalbought = manacrystal.isActiveAndEnabled;
        data.guildbought = guild.isActiveAndEnabled;
        data.healthbought = health.isActiveAndEnabled;
        data.staminabought = stamina.isActiveAndEnabled;
        data.manabought = mana.isActiveAndEnabled;
        data.merchantbought = merchant.isActiveAndEnabled;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }
    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SaveData.dat", FileMode.Open);
            SavedData data = (SavedData)bf.Deserialize(file);
            file.Close();
            if(manager.LoadBuilding(data.manacrystalbought, manacrystal_building)) manacrystal.LoadUpgrade(data.guild_lvl);
            if(manager.LoadBuilding(data.guildbought, guild_building)) guild.LoadUpgrade(data.guild_lvl);
            if(manager.LoadBuilding(data.healthbought, health_building)) health.LoadUpgrade(data.guild_lvl);
            if(manager.LoadBuilding(data.staminabought, stamina_building)) stamina.LoadUpgrade(data.guild_lvl);
            if(manager.LoadBuilding(data.manabought, mana_building)) mana.LoadUpgrade(data.guild_lvl);
            if(manager.LoadBuilding(data.merchantbought, merchant_building)) merchant.LoadUpgrade(data.guild_lvl);
            control.money = data.money;
            control.healthpotion = data.healthpotion;
            control.staminapotion = data.staminapotion;
            control.manapotion = data.manapotion;
            control.mana = data.mana;
            control.redflower = data.redflower;
            control.greenflower = data.greenflower;
            control.blueflower = data.blueflower;
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

[Serializable]
class SavedData
{
    public int manacrystal_lvl;
    public int guild_lvl;
    public int health_lvl;
    public int stamina_lvl;
    public int mana_lvl;
    public int merchant_lvl;
    public int money;
    public int healthpotion;
    public int staminapotion;
    public int manapotion;
    public int mana;
    public int redflower;
    public int greenflower;
    public int blueflower;
    public bool manacrystalbought;
    public bool guildbought;
    public bool healthbought;
    public bool staminabought;
    public bool manabought;
    public bool merchantbought;
}