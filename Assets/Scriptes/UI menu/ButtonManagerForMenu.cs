using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagerForMenu : MonoBehaviour
{
    [SerializeField] GameObject panelAuthors;

    public void ButtoninMenuCllick()
    {
        switch (gameObject.name)
        {
            case "ButtonPlay":
                SceneManager.LoadScene(+1);
                break;

            case "ButtonAuthors":
                panelAuthors.SetActive(true);
                break;

            case "ButtonBackAuthors":
                panelAuthors.SetActive(false);
                break;

            case "ButtonExit":
                Application.Quit();
                break;
        }
    }
}
