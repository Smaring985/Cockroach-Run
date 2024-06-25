using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Transform _point;
    [SerializeField] float _distanceRay;
    [SerializeField] float _speedRebound;
    [SerializeField] float _reloadRebound;
    [SerializeField] bool _aim;
    [SerializeField] bool _rebound;
    [SerializeField] int _damageForEnemy;
    [SerializeField] LayerMask _enemyMask;
    [SerializeField] Ray _rayAim;
    [SerializeField] RaycastHit _hit;
    [SerializeField] CharacterController _characterController;
    [SerializeField] Vector3 _direction;



    private void Update()
    {
        Ray _rayAim = new Ray(_point.position, _point.forward * _distanceRay);
        RaycastHit hit;


        _aim = Physics.Raycast(_rayAim, out hit, _distanceRay, _enemyMask);

        if (_aim && Input.GetMouseButtonDown(0) && hit.collider.gameObject.TryGetComponent(out IDamagable enemy))
        {
            enemy.GetDamage(_damageForEnemy);
            _rebound = true;
            StartCoroutine(nameof(_reboundReload));
        }

        if (_rebound)
        {
            Rebound();
        }
    }

    private void Rebound()
    {
        _direction = transform.forward;
        _characterController.Move(_direction * _speedRebound * Time.deltaTime);
        
    }

    public IEnumerator _reboundReload()
    {
        yield return new WaitForSeconds(_reloadRebound);
        _rebound = false;
    }

    /*private void AimInEnemy()
    {
        Ray _rayAim = new Ray(_point.position, _point.forward * _distanceRay);
        RaycastHit hit;

        _aim = Physics.Raycast(_rayAim, out hit);

    }
   
   /* private void Damage()
    {
        if (_aim && Input.GetMouseButtonDown(0) && hit.collider.gameObject.TryGetComponent(out IDamagable enemy))
        {
            enemy.GetDamage(_damageForEnemy);
        }
    }
   */

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_point.position, _point.forward * _distanceRay);
    }
}
