using System.Collections.Generic;
using UdemyProject2.Controllers;
using UdemyProject2.Enums;
using UdemyProject2.Utilities;
using UnityEngine;


namespace UdemyProject2.Managers
{
    public class EnemyManager : SingletonObjects<EnemyManager>
    {
        [SerializeField] private EnemyController[] _enemyPrefab;
        
        private Dictionary<EnemyEnum, Queue<EnemyController>> _enemies =
            new Dictionary<EnemyEnum, Queue<EnemyController>>(); 

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
            for (int i = 0; i < _enemyPrefab.Length; i++)
            {
                Queue<EnemyController> enemyControllers = new Queue<EnemyController>();
                for (int j = 0; j < 10; j++)
                {
                    EnemyController newEnemy = Instantiate(_enemyPrefab[i]);
                    newEnemy.gameObject.SetActive(false);
                    newEnemy.transform.parent = this.transform;
                    enemyControllers.Enqueue(newEnemy);
                }
                _enemies.Add((EnemyEnum)i,enemyControllers);
            }
        }

        public void SetPool(EnemyController enemyController)
        {
            enemyController.gameObject.SetActive(false);
            enemyController.transform.parent = this.transform;

            Queue<EnemyController> enemyControllers = _enemies[enemyController.EnemyType];
            enemyControllers.Enqueue(enemyController);
        }

        public EnemyController GetPool(EnemyEnum enemyType)
        {
            Queue<EnemyController> enemyControllers = _enemies[enemyType];

            if (enemyControllers.Count == 0)
            {
                EnemyController newEnemy = Instantiate(_enemyPrefab[(int) enemyType]);
                enemyControllers.Enqueue(newEnemy);
            }
            return enemyControllers.Dequeue();
        }
    }
}