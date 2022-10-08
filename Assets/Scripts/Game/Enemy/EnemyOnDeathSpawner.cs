using TDS.Game.Objects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TDS.Game.Enemy
{
    public class EnemyOnDeathSpawner : MonoBehaviour
    {
        [SerializeField] private EnemyDeath _enemyDeath;
        [SerializeField] private ObjectInfo[] _spawnObjects;

        private float _totalSummaryChance;
        private Transform _cachedTransform;
        private void Awake()
        {
            _cachedTransform = transform;
            
            foreach (ObjectInfo spawnObject in _spawnObjects)
            {
                _totalSummaryChance += spawnObject.Chance;
            }
        }

        private void OnEnable()
        {
            _enemyDeath.OnDead += Spawn;
        }

        private void OnDisable()
        {
            _enemyDeath.OnDead -= Spawn;
        }

        private void Spawn()
        {
            if (_spawnObjects == null || _spawnObjects.Length == 0)
            {
                return;
            }
            
            float randomSpawnValue = Random.Range(0f, _totalSummaryChance);
            float currentSummaryChance = 0;
            
            foreach (ObjectInfo spawnObject in _spawnObjects)
            {
                currentSummaryChance += spawnObject.Chance;
                if (randomSpawnValue <= currentSummaryChance)
                {
                    if (spawnObject.GameObject == null)
                    {
                        break;
                    }

                    InstantiateObject(spawnObject);
                }
            }
        }

        private void InstantiateObject(ObjectInfo spawnObject)
        {
            Vector2 position = _cachedTransform.position;
            GameObject instance = Instantiate(spawnObject.GameObject, position, Quaternion.identity);
            Rigidbody2D component = instance.GetComponent<Rigidbody2D>();
            Vector2 spawnPosition = position + Random.insideUnitCircle * 2;
            component.MovePosition(spawnPosition);
        }

        private void OnValidate()
        {
            foreach (ObjectInfo spawnObject in _spawnObjects)
            {
                if (spawnObject.GameObject == null)
                {
                    continue;
                }
                
                spawnObject.UpdateName();
            }
        }
    }
}