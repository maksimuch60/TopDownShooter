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
                ApplyEffect(col);
            }
        }

        private void ApplyEffect(Collision2D col)
        {
            PlayerHp playerHp = col.collider.GetComponent<PlayerHp>();
            playerHp.AddHp(_hpRestoreValue);
            Destroy(gameObject);
        }
    }
}