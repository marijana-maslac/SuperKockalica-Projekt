using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;

    AsyncOperation async;

    public void LoadScreen(int newGame)
    {
        StartCoroutine(LoadingGame(newGame));
    }
    IEnumerator LoadingGame(int newGame)
    {
        loadingScreen.SetActive(true);
        async = SceneManager.LoadSceneAsync(newGame);
        async.allowSceneActivation = false;
        while (async.isDone==false)
        {
            slider.value = async.progress;
            if (async.progress == 0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
