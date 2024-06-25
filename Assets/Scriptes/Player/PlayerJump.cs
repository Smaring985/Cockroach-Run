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
    [SerializeField]  bool isGrounded;


    private void Update()
    {

         isGrounded = Physics.Raycast(_isGrounded.position, Vector3.down, _rayDistance, _ground);

        _velocity.y += _gravity * Time.deltaTime;

        _characterController.Move(_velocity * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _velocity.y += Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }
        if (isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
        

    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_isGrounded.position, Vector3.down * _rayDistance);
    }
}
