using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMove : MonoBehaviour
{
    [SerializeField] float _speedMove;
    [SerializeField] float xRotatiom;
    [SerializeField] Transform _transform;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _speedMove * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _speedMove * Time.deltaTime;

        xRotatiom -= mouseY;
        xRotatiom = Mathf.Clamp(xRotatiom, -17, 17);
        _transform.localRotation = Quaternion.Euler(xRotatiom, 0, 0);
    }
}
