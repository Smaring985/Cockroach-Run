using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] CharacterController _characterController;

    [SerializeField] LayerMask _ground;
    public Vector3 _velocity;

    [SerializeField] float _gravity;
    [SerializeField] float _jumpHeight;
    [SerializeField] float _rayDistance;

    [SerializeField] Transform _isGrounded;
    bool gravityNull;


    private void Update()
    {

        bool isGrounded = Physics.Raycast(_isGrounded.position, Vector3.down, _rayDistance, _ground);

        if (isGrounded && _velocity.y < 0)
        {
            _velocity.y = 0f;
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            _velocity.y += Mathf.Sqrt(_jumpHeight * -3f * _gravity);
        }

        _velocity.y -= _gravity;
        _characterController.Move(_velocity * _gravity * Time.deltaTime);
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(_isGrounded.position, Vector3.down * _rayDistance);
    }
}
