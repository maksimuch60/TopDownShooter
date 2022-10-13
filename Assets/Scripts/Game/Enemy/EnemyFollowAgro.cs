using System;
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

        [Header("Obstacles")]
        [SerializeField] private LayerMask _obstacleMask;

        private Transform _cachedTransform;

        private bool _isInAgro;

        private void Awake()
        {
            _cachedTransform = transform;
        }

        private void Start()
        {
            _triggerObserver.OnTriggerStay += OnStayed;
            _triggerObserver.OnTriggerExit += OnExited;
        }

        private void OnStayed(Collider2D other)
        {
            if (_isInAgro)
            {
                return;
            }
            
            Vector3 currentPosition = _cachedTransform.position;
            Vector3 direction = other.ClosestPoint(currentPosition) - (Vector2)currentPosition;
            RaycastHit2D hit2D = Physics2D.Raycast(currentPosition, direction, direction.magnitude, _obstacleMask);

            
            if (hit2D.collider == null)
            {
                EnterFollow();
            }
        }

        private void OnExited(Collider2D other)
        {
            _enemyFollow.Deactivate();
            _enemyBackToIdle.Activate();
            _isInAgro = false;
        }

        private void EnterFollow()
        {
            _isInAgro = true;
            
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
    }
}