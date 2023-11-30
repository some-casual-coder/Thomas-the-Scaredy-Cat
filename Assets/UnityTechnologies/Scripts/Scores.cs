using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scores : MonoBehaviour
{
   
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("MENU!");
    }

    public void Restart()
    {
        Debug.Log("RESTART!");
        SceneManager.LoadScene(1);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextGame()
    {
        Debug.Log("NEXT!");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}