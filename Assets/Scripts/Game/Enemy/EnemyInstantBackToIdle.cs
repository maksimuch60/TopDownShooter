using System;
using TDS.Game.Enemy.Idle;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyInstantBackToIdle : EnemyBackToIdle
    {
        [SerializeField] private EnemyIdle _enemyIdle;

        private void OnEnable()
        {
            _enemyIdle.enabled = true;
        }

        private void OnDisable()
        {
            _enemyIdle.enabled = false;
        }
    }
}