using System;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private PlayerAnimation _playerAnimation;

        [SerializeField] private Transform _spawnPosition;
        
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private float _fireDelay = 3f;

        private float _timer;
        
        

        private Transform _cachedTransform;

        private void Awake()
        {
            _cachedTransform = transform;
        }

        private void Update()
        {
            TickTimer();
            
            if (CanAttack())
            {
                Attack();
            }
        }

        private void TickTimer()
        {
            _timer -= Time.deltaTime;
        }

        private bool CanAttack()
        {
            return Input.GetButton("Fire1") && _timer <= 0;
        }

        private void Attack()
        {
            Instantiate(_bulletPrefab, _spawnPosition.position, _cachedTransform.rotation);
            _timer = _fireDelay;
            _playerAnimation.PlayAttack();
        }
    }
}