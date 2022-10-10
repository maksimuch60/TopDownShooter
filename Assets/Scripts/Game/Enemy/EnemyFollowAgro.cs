using TDS.Game.Enemy.Movement;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyFollowAgro : MonoBehaviour
    {
        [SerializeField] private EnemyFollow _enemyFollow;
        [SerializeField] private EnemyIdle _enemyIdle;
        [SerializeField] private EnemyBackToIdle _enemyBackToIdle;
        [SerializeField] private TriggerObserver _triggerObserver;

        private void Start()
        {
            _triggerObserver.OnTriggerEnter += OnEntered;
            _triggerObserver.OnTriggerExit += OnExited;
        }

        private void OnEntered(Collider2D col)
        {
            if (_enemyIdle.IsActive)
            {
                _enemyIdle.Deactivate();
            }
            else
            {
                _enemyBackToIdle.Deactivate();
            }

            _enemyFollow.Activate();
        }

        private void OnExited(Collider2D obj)
        {
            _enemyFollow.Deactivate();
            _enemyBackToIdle.Activate();
        }
    }
}