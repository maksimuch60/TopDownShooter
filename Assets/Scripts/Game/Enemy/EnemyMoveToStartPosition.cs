using System;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyMoveToStartPosition : MonoBehaviour
    {
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private TriggerObserver _triggerObserver;
        
        [SerializeField] private float _allowance = 0.1f;

        private GameObject _startPoint;

        private void Awake()
        {
            _startPoint = new GameObject();
        }

        private void Start()
        {
            _triggerObserver.OnTriggerExit += OnExited;
        }

        private void Update()
        {
            //TODO: Checking achievment of start point
        }

        private void OnDestroy()
        {
            Destroy(_startPoint);
        }

        private void OnExited(Collider2D obj)
        {
            SetTarget(_startPoint.transform);
        }

        private void SetTarget(Transform target)
        {
            _enemyMovement.SetTarget(target);
        }
    }
}