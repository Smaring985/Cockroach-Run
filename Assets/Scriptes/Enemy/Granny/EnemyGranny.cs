using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGranny : MonoBehaviour
{
    [SerializeField] NavMeshAgent _granny;
    [SerializeField] Transform _playerBody;
    [SerializeField] GameObject _cloudPrefab;
    [SerializeField] Transform[] _spawner = new Transform[5];
    //[SerializeField] float MoveDirections;
    bool _spawnRegul = true;
    [SerializeField] float _spawnRegulSpeed;
    [SerializeField] PlayerDamageGranny _playerDamageGranny;

  

    private void Update()
    {
        MoveEnemy();
        
        if (_spawnRegul && !_playerDamageGranny._freezing)
        {
            SpawnerCouds();
            _spawnRegul = false;
            StartCoroutine(nameof(SpawnerCloudsRegul));
        }
    }

    private void MoveEnemy()
    {
        _granny.destination = _playerBody.position;
    }

    private void SpawnerCouds()
    {
        var _spawnRandom = _spawner[UnityEngine.Random.Range(0, 5)];
        Instantiate(_cloudPrefab, _spawnRandom);
    }

    private IEnumerator SpawnerCloudsRegul()
    {
        yield return new WaitForSeconds(_spawnRegulSpeed);
        _spawnRegul = true;
    }

    
}
