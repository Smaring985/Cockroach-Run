using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    [SerializeField] float _speedCamera;
    [SerializeField] float xRotation;

    [SerializeField]  Transform _player;


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _speedCamera * Time.deltaTime;

        _player.Rotate(Vector3.up * mouseX);    
    }
}
