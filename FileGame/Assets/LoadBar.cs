using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    public void LoadLevel (int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operatıon = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (slider.value <0.9f) 
        {
            //float progress = Mathf.Clamp01(operation.progress / .9f);

           // slider.value = progress;
           // progressText.text = progress * 100f + "%";

            yield return null;
        }
    }
}
