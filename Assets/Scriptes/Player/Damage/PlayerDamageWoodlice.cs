using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageWoodlice : MonoBehaviour, IDamagable
{
    [SerializeField] float _health;

    public void GetDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
