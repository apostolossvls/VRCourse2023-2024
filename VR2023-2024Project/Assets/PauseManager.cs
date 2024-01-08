using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private KeyCode pauseKey = KeyCode.Escape;
    [SerializeField] private GameObject pauseScreen;

    [Space(15)]
    [Header("Things to Disable")]
    [SerializeField] private ThirdPersonController controller;

    bool isPause = false;

    bool cursorVisibility;
    CursorLockMode cursorState;

    // Start is called before the first frame update
    void Start()
    {
        isPause = true;
        Unpause();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(pauseKey))
        {
            if (!isPause)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
    }

    public void Pause()
    {
        isPause = true;

        cursorVisibility = Cursor.visible;
        cursorState = Cursor.lockState;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        //disable
        controller.enabled = false;

        //pause
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Unpause()
    {
        isPause = false;

        Cursor.visible = cursorVisibility;
        Cursor.lockState = cursorState;

        pauseScreen.SetActive(false);
        Time.timeScale = 1f;

        controller.enabled = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
