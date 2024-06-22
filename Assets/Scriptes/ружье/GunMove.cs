using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMove : MonoBehaviour
{
    [SerializeField] float _speedMove;
    [SerializeField] float xRotation;
    [SerializeField] Transform _transform;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _speedMove * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _speedMove * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -17, 17);
        _transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
