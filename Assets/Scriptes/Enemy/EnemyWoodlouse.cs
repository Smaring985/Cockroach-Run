using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWoodlouse : MonoBehaviour
{
    [SerializeField] NavMeshAgent _woodlouse;
    [SerializeField] Transform _playerBody;

    [SerializeField] bool _reloadDamage;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && _reloadDamage)
        {
            PlayerHP.instance.GetDamage(1);
            _reloadDamage = false;
            StartCoroutine(nameof(playerDamageReload));
        }

    }

    private void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        _woodlouse.destination = _playerBody.position;
    }
    private IEnumerator playerDamageReload()
    {
        yield return new WaitForSeconds(1);         
        _reloadDamage = true;
    }
    
}
