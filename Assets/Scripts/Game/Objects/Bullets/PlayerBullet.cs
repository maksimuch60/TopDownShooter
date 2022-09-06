using TDS.Constants;
using TDS.Game.Enemy;
using UnityEngine;

namespace TDS.Game.Objects.Bullets
{
    class PlayerBullet : BulletBase
    {
        protected override void CheckCollision(Collider2D col)
        {
            if (col.CompareTag(Tags.Enemy))
            {
                EnemyHp enemyHp = col.gameObject.GetComponent<EnemyHp>();
                enemyHp.RemoveHp(Damage);
            }
        }
    }
}