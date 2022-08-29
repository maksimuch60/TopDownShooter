using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void PlayShot()
        {
            _animator.SetTrigger("Shoot");
        }

        public void PlayDeath()
        {
            _animator.SetTrigger("Death");
        }
    }
}