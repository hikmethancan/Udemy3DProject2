
using UdemyProject2.Enums;
using UdemyProject2.Managers;
using UnityEngine;

namespace UdemyProject2.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] private float _maxSpawnTime = 10f;
        [SerializeField] private float _min = .1f;
        [SerializeField] private float _max = 10f;


        private int _index = 0;
        private float _maxAddEnemyTime; 
        private float _currentSpawnTime = 0f;

        public bool CanIncrease => _index < EnemyManager.Instance.Count;
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

            if (!CanIncrease) return;

            if (!(_maxAddEnemyTime < Time.time)) return;
            _maxAddEnemyTime = Time.time + EnemyManager.Instance.AddDelayTime;
            IncreaseIndex();
            // index artis 
        }

        private void IncreaseIndex()
        {
            if (CanIncrease)
            {
                _index++;
            }
        }

        private void GetRandomMaxTime()
        {
            _maxSpawnTime = Random.Range(_min, _max);
        }

        private void Spawn()
        {
            var newEnemy = EnemyManager.Instance.GetPool((EnemyEnum)Random.Range(0,_index));
            newEnemy.transform.parent = this.transform;
            newEnemy.transform.position = this.transform.position;
            newEnemy.gameObject.SetActive(true);
            
            _currentSpawnTime = 0f;
            GetRandomMaxTime();
        }
    }
}