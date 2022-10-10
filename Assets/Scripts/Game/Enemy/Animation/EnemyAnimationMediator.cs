using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAnimationMediator : MonoBehaviour
    {
        [SerializeField] private EnemyMeleeAttack _enemyMeleeAttack;
        
        
        public void PerformDamage()
        {
            Debug.LogError("PerformDamage");
            _enemyMeleeAttack.PerformDamage();
        }
    }
}