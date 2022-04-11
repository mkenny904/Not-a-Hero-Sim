using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    //Starts a new game by loading the main scene.
    public void StartNewGame(){
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame(){
        // Is triggered when the user presses "Quit" in the menu options.
        // Exits the application. Does not work in preview mode. Only in build mode.
        Application.Quit();
    }
}
