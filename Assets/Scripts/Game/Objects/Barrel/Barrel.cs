using System;
using TDS.Constants;
using TDS.Game.Interfaces;
using UnityEngine;

namespace TDS.Game.Objects.Barrel
{
    public class Barrel : MonoBehaviour
    {
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private int _damage;

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag(Tags.PlayerBullet))
            {
                Explode();
                Debug.Log("Explode");
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, _radius);
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
        }
    }
}