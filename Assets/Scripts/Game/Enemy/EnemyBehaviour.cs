using UnityEngine;

namespace TDS.Game.Enemy
{
    public abstract class EnemyBehaviour : MonoBehaviour
    {
        private bool _isActive;

        private void Update()
        {
            if (_isActive)
            {
                OnActiveUpdate();
            }
        }

        public virtual void Activate()
        {
            _isActive = true;
        }

        public virtual void Deactivate()
        {
            _isActive = false;
        }

        protected virtual void OnActiveUpdate(){}
        protected virtual void OnUpdate(){}

    }
}