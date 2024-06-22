using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] CharacterController _characterController;


    [SerializeField] LayerMask _ground;
    Vector3 _velocity;

    [SerializeField] float _gravity;
    [SerializeField] float _jumpHeight;
    [SerializeField] float _rayDistance;
    bool gravityNull;


    private void Update()
    {
        Gravity();
    }



    private void Gravity()
    {
        if (!gravityNull)
            _velocity.y -= _gravity;

        _characterController.Move(_velocity * _gravity * Time.deltaTime);

    }
}
