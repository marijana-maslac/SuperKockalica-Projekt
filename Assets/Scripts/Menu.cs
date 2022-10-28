using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitANSW_YES()  
    {
        Application.Quit();     //zatvara igru
        Debug.Log("Game Over"); // provjeru radim kroz konzolu da provjerimo jel se izvrsava
    }
   
}
