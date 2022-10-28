using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHide : MonoBehaviour
{
    public GameObject About;
    public GameObject MainMenu;
    public GameObject QuitQuestion;
    public GameObject PlayAgain;

    public void ShowHideMainMenu()
    {
        About.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(true);
        QuitQuestion.gameObject.SetActive(false);
    }

    public void ShowHideAbout()
    {
        About.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(false);
    }
    public void ShowHideQuitQuestion()
    {
        QuitQuestion.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(false);
    }
    public void ShowHidePlayAgain()
    {
        PlayAgain.gameObject.SetActive(false);
        LifeHealth.health = 1;
    }
}
