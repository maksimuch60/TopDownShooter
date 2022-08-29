using System;
using System.Collections;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private EnemyAnimation _enemyAnimation;
        [SerializeField] private EnemyHp _enemyHp;

        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPosition;
        
        [SerializeField] private float _fireDelay;
        [SerializeField] private EnemyTrigger _enemyTrigger;

        private Transform _cachedTransform;

        private void Awake()
        {
            _cachedTransform = transform;
        }

        private void OnEnable()
        {
            _enemyHp.OnLivesEnded += StopCoroutine;
        }

        private void OnDisable()
        {
            _enemyHp.OnLivesEnded -= StopCoroutine;
        }

        private void Start()
        {
            StartCoroutine(Attack());
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
            Debug.Log("Не стрелять");
            StopAllCoroutines();
        }
    }
}