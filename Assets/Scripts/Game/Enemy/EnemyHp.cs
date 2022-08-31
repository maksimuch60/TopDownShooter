using System;
using TDS.Constants;
using TDS.Game.Objects;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyHp : MonoBehaviour
    {
        [SerializeField] private int _originalHp;

        private int _hp;

        public event Action<int> OnHpChanged;

        private void Awake()
        {
            _hp = _originalHp;
        }

        public void RemoveHp(int lives)
        {
            _hp -= lives;
            OnHpChanged?.Invoke(_hp);
        }
    }
}