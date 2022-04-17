
using UdemyProject2.Enums;
using UdemyProject2.Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UdemyProject2.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
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
            var newEnemy = EnemyManager.Instance.GetPool((EnemyEnum)Random.Range(0,4));
            newEnemy.transform.parent = this.transform;
            newEnemy.transform.position = this.transform.position;
            newEnemy.gameObject.SetActive(true);
            
            _currentSpawnTime = 0f;
            GetRandomMaxTime();
        }
    }
}