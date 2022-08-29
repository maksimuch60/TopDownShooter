using System;
using TDS.Constants;
using TDS.Game.Objects;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerHp : MonoBehaviour
    {
        [SerializeField] private int _originalLives;

        private int _lives;
        private bool _isAlive;

        public event Action OnLivesEnded;

        private void Awake()
        {
            _lives = _originalLives;
            _isAlive = true;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag(Tags.EnemyBullet) && _isAlive)
            {
                Bullet bullet = col.collider.GetComponent<Bullet>();
                ChangeLives(bullet.Damage);
            }
        }

        private void ChangeLives(int lives)
        {
            _lives += lives;
            if (_lives <= 0)
            {
                OnLivesEnded?.Invoke();
                _isAlive = false;
            }
        }
    }
}