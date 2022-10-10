using System;
using UnityEngine;

namespace TDS.Game.Enemy
{
    [RequireComponent(typeof(EnemyFollowAgro))]
    [RequireComponent(typeof(EnemyAgroAttack))]
    public class EnemyStarter : MonoBehaviour
    {
        [SerializeField] private EnemyIdle _enemyIdle;

        private void Start()
        {
            _enemyIdle.Activate();
        }
    }
}