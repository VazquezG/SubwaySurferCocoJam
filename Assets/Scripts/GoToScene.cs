using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public string SceneName;


    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1;//resume time
        SceneName = sceneName;
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    // Corrutina para cargar la escena de manera asincrónica
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Espera hasta que la escena haya terminado de cargar
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
