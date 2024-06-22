using System.Collections;
using System.Collections.Generic;
using TreeEditor;

using UnityEngine;

public class EnemySpider : MonoBehaviour
{
    [SerializeField] Transform m_player;
    [SerializeField] float m_targetOffset;
    [SerializeField] float m_speed;
    [SerializeField] float m_minAttackeDistance;
    [SerializeField] LayerMask m_wallLayer;
    [SerializeField] LayerMask m_groundLayer;

    private Vector3 _target;

    private void Update()
    {
        if(!Physics.Linecast(transform.position, m_player.position, m_wallLayer))
        {
            Vector3 target = m_player.position + new Vector3(0, 0, 2f);
            Debug.Log("Ïîïàë");

            if (Vector3.Distance(transform.position, m_player.position) > m_minAttackeDistance)
            {
                if (Physics.Raycast(target, Vector3.down, out RaycastHit hit, m_groundLayer))
                {
                    _target = hit.point;

                }
            }
        }

        if (_target != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target, m_speed);
            if(transform.position == _target) 
            {
                Debug.Log("ÑÁÐÎÑÈË");
                _target = Vector3.zero;
            }
        }
    }
    private void OnDrawGizmos()
    {
        if (!Physics.Linecast(transform.position, m_player.position, m_wallLayer))
        {
            Vector3 target = m_player.position + new Vector3(0, 0, 2f);

            Gizmos.DrawLine(transform.position, target);

            if (Physics.Raycast(target, Vector3.down, out RaycastHit hit, m_groundLayer))
            {
                
                Gizmos.DrawLine(hit.point, target);
               

            }
        }
    }

}

public class EnemyHP: MonoBehaviour
{
    [SerializeField] float m_helth;

    public void GetDamage(float damage)
    {
        if(damage > m_helth)
        {
            m_helth = 0;
        }

        if(damage < 0)
        {
            return;
        }

        m_helth -= damage;
    }

    
}
