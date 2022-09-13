using TDS.Game.Enemy.Animation;
using UnityEngine;

namespace TDS.Game.Enemy.Attack
{
    public class EnemyRangeAttack : EnemyAttack
    {
        [SerializeField] private EnemyAnimation _enemyAnimation;

        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPosition;

        [SerializeField] private float _delayTimer;
        
        private Transform _cachedTransform;

        private void Awake()
        {
            _cachedTransform = transform;
        }

        private void Update()
        {
            TickTimer();
        }

        public override void Attack()
        {
            if (CanAttack())
            {
                _enemyAnimation.PlayShot();
                Instantiate(_bulletPrefab, _bulletSpawnPosition.position, _cachedTransform.rotation);
            }
        }

        private bool CanAttack()
        {
            return _delayTimer <= 0;
        }

        private void TickTimer()
        {
            _delayTimer -= Time.deltaTime;
        }
    }
}