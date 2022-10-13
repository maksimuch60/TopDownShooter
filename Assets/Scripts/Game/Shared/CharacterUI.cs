using System;
using TDS.Game.Interfaces;
using TDS.Game.UI;
using UnityEngine;

namespace TDS.Game.Shared
{
    public class CharacterUI : MonoBehaviour
    {
        [SerializeField] private HpBar _hpBar;

        private IHealth _health;

        private void Awake()
        {
            Construct(GetComponentInChildren<IHealth>());
        }

        private void OnDestroy()
        {
            if (_health != null)
            {
                _health.OnHpChanged -= HpChanged;
            }
        }

        private void Construct(IHealth health)
        {
            _health = health;

            if (_health != null)
            {
                _health.OnHpChanged += HpChanged;
                HpChanged(_health.CurrentHp);
            }
        }

        private void HpChanged(int currentHp)
        {
            float fillAmount = currentHp / (float) _health.MaxHp;
            _hpBar.SetFill(fillAmount);
        }
    }
}