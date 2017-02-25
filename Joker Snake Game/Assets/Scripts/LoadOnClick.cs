using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {

    public void LoadScene()
    {
        SceneManager.LoadScene("MiniGame");
    }// load the scene , start the game

    public void doExitGame()
    {
        Application.Quit();
    }// exit the application

}// load on click events
