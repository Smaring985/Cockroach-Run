using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagePomidorHpRegul : MonoBehaviour
{
    [SerializeField] GameObject _1_pomidor;
    [SerializeField] GameObject _2_pomidor;
    [SerializeField] GameObject _3_pomidor;
    [SerializeField] GameObject _4_pomidor;
    [SerializeField] GameObject _5_pomidor;


    void Update()
    {
        switch (PlayerHP.instance.m_health)
        {
                case 4:
                _5_pomidor.SetActive(false);
                break;

                case 3:
                _4_pomidor.SetActive(false);
                break;

                case 2:
                _3_pomidor.SetActive(false);
                break;

                case 1:
                _2_pomidor.SetActive(false);
                break;

                case 0:
                _1_pomidor.SetActive(false);
                break;
        }
    }
}
