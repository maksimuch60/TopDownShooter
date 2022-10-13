using System;

namespace TDS.Game.Interfaces
{
    public interface IHealth
    {
        int CurrentHp { get;}
        int MaxHp { get;}

        event Action<int> OnHpChanged;

        void AddHp(int hp);

        void RemoveHp(int hp);
    }
}