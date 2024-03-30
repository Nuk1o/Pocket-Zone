using System.Collections.Generic;
using Units;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemiesController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawnPoints;
    [SerializeField] private List<Enemy> _enemy;
    [SerializeField] private int _numOfSpawns;

    private void Start()
    {
        for (int i = 0; i < _numOfSpawns; i++)
        {
            var _randomValueEnemy = Random.Range(0, _enemy.Count);
            var _randomValueSpawn = Random.Range(0, _spawnPoints.Count);
            Instantiate(_enemy[_randomValueEnemy], _spawnPoints[_randomValueSpawn].transform.position,
                quaternion.identity);
            _spawnPoints.Remove(_spawnPoints[_randomValueSpawn]);
        }
    }
}
