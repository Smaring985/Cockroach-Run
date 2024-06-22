using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootDrob : MonoBehaviour
{

    [SerializeField] Transform _transform;

    [SerializeField] LayerMask _enemy;

    [SerializeField] float _rayDistance;
    [SerializeField] float damage;
    [SerializeField] bool shoot;

    [SerializeField] EnemyHP _enemyHP;
   
    void Update()
    {
       
       shoot = Physics.Raycast(_transform.position, transform.forward, _rayDistance, _enemy);

       DamageEnemy();
    }

    private void DamageEnemy()
    {
        if (shoot && Input.GetMouseButtonDown(0)) 
        {

            Debug.Log("YES");
            _enemyHP.GetDamage(damage);

        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(_transform.position, _transform.forward * _rayDistance);
    }
}
