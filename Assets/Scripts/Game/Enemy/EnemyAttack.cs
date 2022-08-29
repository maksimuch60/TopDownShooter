using System.Collections;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPosition;
        
        [SerializeField] private float _fireDelay;
        [SerializeField] private EnemyTrigger _enemyTrigger;

        private Transform _cachedTransform;

        private void Awake()
        {
            _cachedTransform = transform;
            StartCoroutine(Attack());
        }

        private IEnumerator Attack()
        {
            while (true)
            {
                if (_enemyTrigger.IsTriggered())
                {
                    Instantiate(_bulletPrefab, _bulletSpawnPosition.position, _cachedTransform.rotation);
                }
                yield return new WaitForSeconds(_fireDelay);
            }
        }
    }
}