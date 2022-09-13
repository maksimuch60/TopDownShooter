using System;
using TDS.Game.Enemy.Movement;
using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyMoveToPlayer : EnemyFollow
    {
        [SerializeField] private EnemyMovement _enemyMovement;

        private Transform _playerTransform;

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerHp>().transform;
        }

        private void OnEnable()
        {
            SetTarget(_playerTransform);
        }

        private void OnDisable()
        {
            SetTarget(null);
        }

        private void SetTarget(Transform target)
        {
            _enemyMovement.SetTarget(target);
        }
    }
}