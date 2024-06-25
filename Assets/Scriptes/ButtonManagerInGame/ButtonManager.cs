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
            case "ButtonRebootScene":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            case "ButtonResume":
                panelPause.SetActive(false);
                Time.timeScale = 1;
                break;
            case "ButtonSetting":
                panelSetting.SetActive(true);
                break;
            case "ButtonBackSettingButton":
                panelSetting.SetActive(false);
                break;

        }
    }

    private void Update()    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panelPause.SetActive(true);
            Time.timeScale = 0;
        }   
    }
}
    