using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UdemyProject2.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] private EnemyController _enemyPrefab;
        [SerializeField] private float _maxSpawnTime = 10f;
        [SerializeField] private float _min = .1f;
        [SerializeField] private float _max = 10f;

        private float _currentSpawnTime = 0f;

        private void OnEnable()
        {
            GetRandomMaxTime();
        }

        private void Update()
        {
            _currentSpawnTime += Time.deltaTime;

            if (_currentSpawnTime > _maxSpawnTime)
            {
                Spawn();
            }
        }

        private void GetRandomMaxTime()
        {
            _maxSpawnTime = Random.Range(_min, _max);
        }

        private void Spawn()
        {
            var newEnemy = Instantiate(_enemyPrefab, transform.position, transform.rotation);
            newEnemy.transform.parent = this.transform;

            _currentSpawnTime = 0f;
            GetRandomMaxTime();
        }
    }
}