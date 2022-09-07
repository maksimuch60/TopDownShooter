using System;
using TDS.Constants;
using TDS.Game.Interfaces;
using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Objects.Barrel
{
    public class Barrel : MonoBehaviour
    {
        [SerializeField] private BarrelAnimation _barrelAnimation;

        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private int _damage;

        [SerializeField] private GameObject _explosion;
        

        private bool _isExplode;

        private void Awake()
        {
            SetExplosionRadius();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag(Tags.PlayerBullet) && !_isExplode)
            {
                Explode();
                PlayAnimation();
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }

        private void SetExplosionRadius()
        {
            Vector3 explosionScale = _explosion.transform.localScale;
            explosionScale.x = _radius;
            explosionScale.y = _radius;
            _explosion.transform.localScale = explosionScale;
        }

        private void Explode()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius, _layerMask);
            foreach (Collider2D col in colliders)
            {
                if (col.gameObject.TryGetComponent(out IHealth health))
                {
                    health.RemoveHp(_damage);
                }
            }

            _isExplode = true;
        }

        private void PlayAnimation()
        {
            _barrelAnimation.PlayExplosion();
        }
    }
}