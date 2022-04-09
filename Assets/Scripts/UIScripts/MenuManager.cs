using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public OptionsMenu optionsMenu;
    public QuestMenu questMenu;

    void Update(){
        // Toggles the options menu with the escape key.
        if(Input.GetKeyDown(KeyCode.Escape)){
            optionsMenu.gameObject.SetActive(!optionsMenu.gameObject.activeSelf);
        }
        // Toggles the quest menu with the Q key.
        if(Input.GetKeyDown(KeyCode.Q)){
            questMenu.gameObject.SetActive(!questMenu.gameObject.activeSelf);
        }
    }
}
