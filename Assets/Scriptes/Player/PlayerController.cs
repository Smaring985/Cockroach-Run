using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _gravity;
    [SerializeField] float _jumpForce;
    [SerializeField] float _distance;

    [SerializeField] bool grounded;

    [SerializeField] CharacterController _characterController;

    [SerializeField] LayerMask _ground;
    Vector3 direction;
    Vector3 velocity;

    [SerializeField] Transform _transformCheck;

    private void Update()
    {


        InputManager();
        Move();

        grounded = Physics.Raycast(_transformCheck.position, _transformCheck.up, _distance);

        if (grounded && velocity.y < 0)
        {
            velocity.y = 2f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            velocity.y += Mathf.Sqrt(_jumpForce * 3f * _gravity);
        }

        velocity.y += _gravity * Time.deltaTime;
        _characterController.Move(velocity * Time.deltaTime);
    }

    private void InputManager()
    {
        float x = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * _speed * Time.deltaTime;

        direction = transform.forward * z + transform.right * x;
    }

    private void Move()
    {
        _characterController.Move(direction); grounded = Physics.Raycast(_transformCheck.position, _transformCheck.up, _distance, _ground);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;    
        Gizmos.DrawRay(_transformCheck.position, _transformCheck.up * _distance);
    }
}
