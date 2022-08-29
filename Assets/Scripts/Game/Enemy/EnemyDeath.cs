using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHp _enemyHp;
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private EnemyAnimation _enemyAnimation;
        [SerializeField] private Collider2D _collider;

        private void OnEnable()
        {
            _enemyHp.OnLivesEnded += PerformDeath;
        }

        private void OnDisable()
        {
            _enemyHp.OnLivesEnded -= PerformDeath;
        }

        private void PerformDeath()
        {
            _enemyAnimation.PlayDeath();
            _collider.enabled = false;
            _enemyMovement.enabled = false;
        }
    }
}