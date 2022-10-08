using System.Collections;
using UnityEngine;

namespace TDS.Game.Objects
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class BulletBase : MonoBehaviour
    {
        [Header(nameof(BulletBase))]
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;
        [SerializeField] private int _damage;

        private Rigidbody2D _rigidbody;

        protected int Damage => _damage;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            SetVelocity();
            StartCoroutine(BulletLifeTime());
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            CheckCollision(col);
            
            Destroy(gameObject);
        }

        protected abstract void CheckCollision(Collider2D col);

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