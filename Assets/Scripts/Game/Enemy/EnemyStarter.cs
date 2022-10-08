using System;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyStarter : MonoBehaviour
    {
        [SerializeField] private EnemyIdle _enemyIdle;

        private void Start()
        {
            _enemyIdle.Activate();
        }
    }
}