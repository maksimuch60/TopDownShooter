using System;
using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyMoveToPlayer : MonoBehaviour
    {
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private TriggerObserver _triggerObserver;
        

        private Transform _playerTransform;

        private void Start()
        {
            _triggerObserver.OnTriggerEnter += OnEntered;
            _triggerObserver.OnTriggerExit += OnExited;
            _playerTransform = FindObjectOfType<PlayerHp>().transform;
        }

        private void OnEntered(Collider2D col)
        {
            SetTarget(_playerTransform);
        }

        private void OnExited(Collider2D col)
        {
            SetTarget(null);
        }

        private void SetTarget(Transform target)
        {
            _enemyMovement.SetTarget(target);
        }
    }
}