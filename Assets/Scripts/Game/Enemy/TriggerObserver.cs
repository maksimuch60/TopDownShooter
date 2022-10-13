using System;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class TriggerObserver : MonoBehaviour
    {
        public event Action<Collider2D> OnTriggerEnter;
        public event Action<Collider2D> OnTriggerExit;
        public event Action<Collider2D> OnTriggerStay;

        private void OnTriggerEnter2D(Collider2D col)
        {
            OnTriggerEnter?.Invoke(col);
        }

        private void OnTriggerExit2D(Collider2D other)
        { 
            OnTriggerExit?.Invoke(other);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            OnTriggerStay?.Invoke(other);
        }
    }
}