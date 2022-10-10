﻿using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAnimation : MonoBehaviour
    {
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Death = Animator.StringToHash("Death");
        private static readonly int Speed = Animator.StringToHash("Speed");

        [SerializeField] private Animator _animator;

        public void PlayShot()
        {
            _animator.SetTrigger(Attack);
        }

        public void PlayDeath()
        {
            _animator.SetTrigger(Death);
        }

        public void PlayAttack()
        {
            _animator.SetTrigger(Attack);
        }

        public void SetSpeed(float speed)
        {
            _animator.SetFloat(Speed, speed);
        }
    }
}