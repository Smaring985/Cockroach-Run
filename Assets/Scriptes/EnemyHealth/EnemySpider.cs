using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using DG.Tweening;

using UnityEngine;

public class EnemySpider : MonoBehaviour
{
    [SerializeField] Transform m_player;
    [SerializeField] float m_targetOffset;
    [SerializeField] float m_speed;
    [SerializeField] float m_minAttackeDistance;
    [SerializeField] LayerMask m_wallLayer;
    [SerializeField] LayerMask m_groundLayer;
    [Space]
    [SerializeField] GameObject m_spiderWeb;
    [SerializeField] float m_startWebSpeed = 2;
    [SerializeField] float m_reloadSpiderWebSpeed;

    private Vector3 _target;
    private bool _canShoot = true;
   

    private void Update()
    {
        if(!Physics.Linecast(transform.position, m_player.position, m_wallLayer))
        {
            Vector3 target = m_player.position + new Vector3(0, 0, 2f);
            Debug.Log("Попал");

            if (Vector3.Distance(transform.position, m_player.position) > m_minAttackeDistance)
            {
                if (Physics.Raycast(target, Vector3.down, out RaycastHit hit, m_groundLayer))
                {
                    if (_canShoot == true)
                    {
                        _target = hit.point;
                        _canShoot = false;
                        m_spiderWeb.SetActive(true);
                        StartCoroutine(ReloatSpiderWeb());
                    }
                        
                        m_spiderWeb.transform.LookAt(_target);
                }
            }
        }

        if (_target != Vector3.zero)
        {
            
             m_spiderWeb.transform.DOScaleZ(Vector3.Distance(m_spiderWeb.transform.position, _target),
                                           m_startWebSpeed).OnComplete(() => {Move();});
            

            if (transform.position == _target) 
            { 
                _target = Vector3.zero;
            }
        }
    }

    private void Move()
    {

        if (_target != Vector3.zero)
        {
           transform.DOMove(_target, m_speed);
        }
        
    }

    private IEnumerator ReloatSpiderWeb()
    {
        yield return new WaitForSeconds(m_reloadSpiderWebSpeed);
        _canShoot = true;
        m_spiderWeb.SetActive(true);
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

    

