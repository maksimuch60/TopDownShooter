using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyMeleeAttack : EnemyAttack
    {
        [SerializeField] private EnemyAnimation _enemyAnimation;

        [SerializeField] private float _attackDelay;
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private int _damage;
        

        private float _delayTimer;

        public void PerformDamage()
        {
            Collider2D col = Physics2D.OverlapCircle(_attackPoint.position, _radius, _layerMask);

            if (col == null)
            {
                return;
            }

            if (col.TryGetComponent(out PlayerHp playerHp))
            {
                playerHp.RemoveHp(_damage);
            }
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            
            TickTimer();
        }

        protected override void OnActiveUpdate()
        {
            base.OnActiveUpdate();
            
            Attack();
        }

        private void Attack()
        {
            if (CanAttack())
            {
                InternalAttack();
            }
        }

        private void InternalAttack()
        {
            _delayTimer = _attackDelay;
            _enemyAnimation.PlayAttack();
        }

        private void TickTimer()
        {
            _delayTimer -= Time.deltaTime;
        }

        private bool CanAttack()
        {
            return _delayTimer <= 0;
        }
    }
}