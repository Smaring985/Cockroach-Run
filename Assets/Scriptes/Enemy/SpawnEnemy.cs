using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] Transform[] _pointSpawnEnemy = new Transform[2];
    [SerializeField] GameObject _enemyPrefabWoodlice;
    [SerializeField] bool _reload;

    private void Update()
    {
       if (!_reload)
        {
            SpawnEnemyRandom();
            _reload = true;
            StartCoroutine(nameof(SpawnerEnemyReload));
        }
    }

    private void SpawnEnemyRandom()
    {
        var _spawnRandom = _pointSpawnEnemy[UnityEngine.Random.Range(0, 2)];
        Instantiate(_enemyPrefabWoodlice, _spawnRandom.position, Quaternion.identity);
    }

    private IEnumerator SpawnerEnemyReload()
    {
        yield return new WaitForSeconds(2);
        _reload = false;
        
    }
}
