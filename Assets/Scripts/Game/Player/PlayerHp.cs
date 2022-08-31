using System;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerHp : MonoBehaviour
    {
        [SerializeField] private int _originalHp;

        private int _hp;

        public event Action<int> OnHpChanged;

        private void Awake()
        {
            _hp = _originalHp;
        }

        public void AddHp(int hp)
        {
            _hp += hp;
            OnHpChanged?.Invoke(_hp);
        }

        public void RemoveHp(int hp)
        {
            _hp -= hp;
            OnHpChanged?.Invoke(_hp);
        }
    }
}