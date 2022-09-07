using UnityEngine;

namespace TDS.Game.Objects.Barrel
{
    public class BarrelAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _barrelAnimator;
        [SerializeField] private Animator _explosionAnimator;

        public void PlayExplosion()
        {
            _barrelAnimator.SetTrigger("Explosion");
            _explosionAnimator.SetTrigger("Explosion");
        }
    }
}