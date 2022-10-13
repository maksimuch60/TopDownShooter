﻿using System;
using TDS.Game.Interfaces;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerHp : MonoBehaviour, IHealth
    {
        [SerializeField] private int _originalHp;
        [SerializeField] private int _maxHp;

        public int CurrentHp { get; private set; }
        public int MaxHp { get; private set; }

        public event Action<int> OnHpChanged;

        private void Awake()
        {
            CurrentHp = _originalHp;
            MaxHp = _maxHp;
            OnHpChanged?.Invoke(CurrentHp);
        }

        public void AddHp(int hp)
        {
            CurrentHp = Mathf.Min(MaxHp, CurrentHp + hp);
            OnHpChanged?.Invoke(CurrentHp);
        }

        public void RemoveHp(int hp)
        {
            CurrentHp = Mathf.Max(0, CurrentHp - hp);
            OnHpChanged?.Invoke(CurrentHp);
        }
    }
}