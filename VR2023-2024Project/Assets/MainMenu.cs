using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance; //singleton
    public Slider progressBar;
	public GameObject progressContinueText;
    public UnityEvent onSelect;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        //DontDestroyOnLoad(gameObject);
    }

    public void StartApp()
    {
        //TODO
        Debug.Log("Start");

        StartCoroutine(LoadYourAsyncScene());
    }

    public void SetMyValue(bool value)
    {
        //todo
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

	progressContinueText.SetActive(true);
	progressBar.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.1f);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SampleScene");
        asyncLoad.allowSceneActivation = false;

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            progressBar.value = asyncLoad.progress;
            
            if (Input.GetKeyDown(KeyCode.E))
            {
		progressContinueText.SetActive(false);
		progressBar.gameObject.SetActive(false);
                asyncLoad.allowSceneActivation = true;
            }
		yield return null;
        }
    }

    public void QuitApp()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Debug.Log("Quit");
        Application.Quit();
#endif
    }
}
