
using System.Collections.Generic;
using UdemyProject2.Controllers;
using UdemyProject2.Utilities;
using UnityEngine;


namespace UdemyProject2.Managers
{
    public class EnemyManager : SingletonObjects<EnemyManager>
    {
        [SerializeField] private EnemyController _enemyPrefab;
        private List<EnemyController> _enemies = new List<EnemyController>();
        [SerializeField] private int _firstInitCount = 10;
        private void Awake()
        {
            SingletonObject(this);
        }

        private void Start()
        {
            InitializeObject();
        }

        private void InitializeObject()
        {
            for (int i = 0; i < _firstInitCount; i++)
            {
                var newEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity, this.transform);
                newEnemy.gameObject.SetActive(false);
                _enemies.Add(newEnemy);
            }
        }

        public void  SetPool(EnemyController enemyController)
        {
            enemyController.gameObject.SetActive(false);
            enemyController.transform.parent = this.transform;
            _enemies.Add(enemyController);
        }

        public EnemyController GetPool()
        {
            if (_enemies.Count == 0)
            {
                InitializeObject();
            }

            var lastObject = _enemies[_enemies.Count - 1];
            _enemies.Remove(lastObject);
            return lastObject;
        }
        
    }
}