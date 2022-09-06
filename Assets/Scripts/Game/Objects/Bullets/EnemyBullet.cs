using TDS.Constants;
using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Objects.Bullets
{
    class EnemyBullet : BulletBase
    {
        protected override void CheckCollision(Collider2D col)
        {
            if (col.CompareTag(Tags.Player))
            {
                PlayerHp playerHp = col.gameObject.GetComponent<PlayerHp>();
                playerHp.RemoveHp(Damage);
            }
        }
    }
}