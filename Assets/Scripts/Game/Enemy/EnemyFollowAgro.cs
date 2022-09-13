using TDS.Game.Enemy.Movement;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyFollowAgro : MonoBehaviour
    {
        [SerializeField] private EnemyFollow _enemyFollow;
        [SerializeField] private EnemyBackToIdle _enemyBackToIdle;
        [SerializeField] private TriggerObserver _triggerObserver;
        
        private void Start()
        {
            _triggerObserver.OnTriggerEnter += OnEntered;
            _triggerObserver.OnTriggerExit += OnExited;
        }

        private void OnEntered(Collider2D col)
        {
            _enemyFollow.enabled = true;
            _enemyBackToIdle.enabled = false;
        }

        private void OnExited(Collider2D obj)
        {
            _enemyFollow.enabled = false;
            _enemyBackToIdle.enabled = true;
        }
    }
}