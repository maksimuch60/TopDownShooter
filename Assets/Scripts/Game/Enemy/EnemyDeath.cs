using System;
using TDS.Game.Enemy.Animation;
using TDS.Game.Enemy.Movement;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyDeath : EnemyBehaviour
    {
        [SerializeField] private EnemyHp _enemyHp;
        [SerializeField] private EnemyDirectMovement enemyDirectMovement;
        [SerializeField] private EnemyAnimation _enemyAnimation;
        [SerializeField] private Collider2D _collider;

        public event Action OnDead;

        private void OnEnable()
        {
            _enemyHp.OnHpChanged += CheckDeath;
        }

        private void OnDisable()
        {
            _enemyHp.OnHpChanged -= CheckDeath;
        }

        private void CheckDeath(int hp)
        {
            if (hp > 0)
            {
                return;
            }

            _enemyHp.OnHpChanged -= CheckDeath;
            
            OnDead?.Invoke();

            _enemyAnimation.PlayDeath();
            _collider.enabled = false;
            enemyDirectMovement.enabled = false;
        }
    }
}