using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    [SerializeField] GameObject panelPause;
    [SerializeField] GameObject panelSetting;

    public void ButtonClick()
    {
        switch (gameObject.name)
        {
            case "Button(rebootScene)":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            case "Button(Resume)":
                panelPause.SetActive(false);
                Time.timeScale = 1;
                break;
            case "Button(Setting)":
                panelSetting.SetActive(true);
                break;
            case "Button(BackSettingButton)":
                panelSetting.SetActive(false);
                break;

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panelPause.SetActive(true);
            Time.timeScale = 0;
        }   
    }
}
    