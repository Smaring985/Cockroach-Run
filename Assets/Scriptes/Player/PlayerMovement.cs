using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _gravity;
    [SerializeField] float _jumpForce;

    [SerializeField] CharacterController _characterController;

    Vector3 direction;
    Vector3 velocity;


    private void Update()
    {
        InputManager();
        Move();
    }

    private void InputManager()
    {
        float x = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * _speed * Time.deltaTime;

        direction = transform.forward * z + transform.right * x;
    }

    private void Move()
    {
        _characterController.Move(direction);
    }

   
}