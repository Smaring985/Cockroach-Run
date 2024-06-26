using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField] float _destroyBullet;

    [SerializeField] FireFromGun _fireFromGun;

    private void Start()
    {
        _fireFromGun= FindAnyObjectByType<FireFromGun>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if ( col.gameObject.TryGetComponent(out IDamagable enemy))
        {
            enemy.GetDamage(1);
            _fireFromGun.m_rebound = true;
            Destroy(gameObject);

            if ( enemy is PlayerDamageGranny)
            {
                enemy.GetDamage(0);
            }
        }
        
        else if ( col.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
