using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] float m_helth = 1;

    public void GetDamage(float damage)
    {
        m_helth -= damage;

        if (m_helth <= 0)
        {
            Destroy(gameObject);
        }


    }
}
