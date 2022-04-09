using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public void SaveGame(){
        // This will be the logic used to save the game
    }

    public void LoadGame(){
        //This will be the logic used to load the game
    }
    
    public void ExitGame(){
        // Is triggered when the user presses "Quit" in the menu options.
        // Exits the application. Does not work in preview mode. Only in build mode.
        Application.Quit();
    }
}
