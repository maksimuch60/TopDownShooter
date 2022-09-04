using System;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAgroAttack : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private EnemyMeleeAttack _enemyMeleeAttack;
        [SerializeField] private EnemyMovement _enemyMovement;
        
        
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
                _enemyMeleeAttack.Attack();
            }
        }

        private void OnEntered(Collider2D col)
        {
            _isInRange = true;
            _enemyMovement.enabled = false;
        }

        private void OnExited(Collider2D col)
        {
            _isInRange = false;
            _enemyMovement.enabled = true;
        }
    }
}