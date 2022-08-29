using System;
using System.Collections;
using UnityEngine;

namespace TDS.Game.Objects
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;
        [SerializeField] private int _damage;

        private Rigidbody2D _rigidbody;

        public int Damage => _damage;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            SetVelocity();
            StartCoroutine(BulletLifeTime());
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            Destroy(gameObject);
        }

        private void SetVelocity()
        {
            _rigidbody.velocity = transform.up * _speed;
        }

        private IEnumerator BulletLifeTime()
        {
            yield return new WaitForSeconds(_lifeTime);

            Destroy(gameObject);
        }
    }
}