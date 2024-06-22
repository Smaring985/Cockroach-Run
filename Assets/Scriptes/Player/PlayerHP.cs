using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] float m_helth = 5;
    [SerializeField] GameObject panelYouDead;
    public void GetDamage(float damage)
    {
        m_helth -= damage;

        if (m_helth <= 0)
        {
            panelYouDead.SetActive(true);
            //Destroy(gameObject);
        }


    }
}
