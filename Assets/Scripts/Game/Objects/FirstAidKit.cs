using TDS.Constants;
using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Objects
{
    public class FirstAidKit : MonoBehaviour
    {
        [SerializeField] private int _hpRestoreValue;

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.CompareTag(Tags.Player))
            {
                PlayerHp playerHp = col.collider.GetComponent<PlayerHp>();
                playerHp.ChangeLives(_hpRestoreValue);
                Destroy(gameObject);
            }
        }
    }
}