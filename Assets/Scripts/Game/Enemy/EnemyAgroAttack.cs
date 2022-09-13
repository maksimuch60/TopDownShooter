using System;
using TDS.Game.Enemy.Attack;
using TDS.Game.Enemy.Movement;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAgroAttack : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private EnemyAttack _enemyAttack;
        [SerializeField] private EnemyFollow _enemyFollow;
        
        
        private bool _isInRange;

        private void Start()
        {
            _triggerObserver.OnTriggerEnter += OnEntered;
            _triggerObserver.OnTriggerExit += OnExited;
        }

        private void Update()
        {
            if (_isInRange)
            {
                _enemyAttack.Attack();
            }
        }

        private void OnEntered(Collider2D col)
        {
            _isInRange = true;
            _enemyFollow.enabled = false;
        }

        private void OnExited(Collider2D col)
        {
            _isInRange = false;
            _enemyFollow.enabled = true;
        }
    }
}