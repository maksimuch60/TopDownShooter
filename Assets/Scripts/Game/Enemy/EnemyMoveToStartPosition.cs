using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyMoveToStartPosition : MonoBehaviour
    {
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private Transform _startTransform;
        
        [SerializeField] private float _allowance = 0.1f;
        

        private void Start()
        {
            _triggerObserver.OnTriggerExit += OnExited;
        }


        private void OnExited(Collider2D obj)
        {
            SetTarget(_startTransform);
        }

        private void SetTarget(Transform target)
        {
            _enemyMovement.SetTarget(target);
        }
    }
}