using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] float _health;
    public float m_health { get { return _health; } set { _health = value; } }
    [SerializeField] GameObject panelYouDead;

    public static PlayerHP instance {  get; private set; }

    private void Awake()
    {
        instance = this;
    }


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
