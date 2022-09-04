using System;
using System.Collections;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyRangeAttack : MonoBehaviour
    {
        [SerializeField] private EnemyAnimation _enemyAnimation;
        [SerializeField] private EnemyDeath _enemyDeath;

        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPosition;
        
        [SerializeField] private float _fireDelay;
        [SerializeField] private EnemyTrigger _enemyTrigger;

        private Transform _cachedTransform;
        IEnumerator _attackRoutine;

        private void Awake()
        {
            _cachedTransform = transform;
            _attackRoutine = Attack();
        }

        private void OnEnable()
        {
            _enemyDeath.OnDead += StopCoroutine;
        }

        private void OnDisable()
        {
            _enemyDeath.OnDead -= StopCoroutine;
        }

        private void Start()
        {
            StartCoroutine(_attackRoutine);
        }

        private IEnumerator Attack()
        {
            while (true)
            {
                if (_enemyTrigger.IsTriggered())
                {
                    _enemyAnimation.PlayShot();
                    Instantiate(_bulletPrefab, _bulletSpawnPosition.position, _cachedTransform.rotation);
                }
                yield return new WaitForSeconds(_fireDelay);
            }
        }

        private void StopCoroutine()
        {
            StopCoroutine(_attackRoutine);
        }
    }
}