using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] float _health = 5;
    [SerializeField] GameObject panelYouDead;
    public void GetDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            panelYouDead.SetActive(true);
            //Destroy(gameObject);
        }


    }
}
