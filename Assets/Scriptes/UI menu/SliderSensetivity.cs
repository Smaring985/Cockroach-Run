using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SliderSensetivity : MonoBehaviour
{
    [SerializeField] CameraMove cameraMove;

    [SerializeField] UnityEngine.UI.Slider sliderSensetivity;

    private void Start()
    {
        if ( !PlayerPrefs.HasKey("seew"))
        {
            cameraMove._speedCamera = 100;

            sliderSensetivity.value = cameraMove._speedCamera;

        }
        else
        {
            Load();
        }
    }

    public void Load()
    {
        PlayerPrefs.GetInt("seew", (int)cameraMove._speedCamera);
    }

    public void Save()
    {
        PlayerPrefs.SetInt("seew", (int)cameraMove._speedCamera);
    }

    public void SliderRegul()
    {
        cameraMove._speedCamera = (int)sliderSensetivity.value;
    }
}
