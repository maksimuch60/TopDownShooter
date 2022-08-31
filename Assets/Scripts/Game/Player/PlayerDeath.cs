using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TDS.Game.Player
{
    public class PlayerDeath : MonoBehaviour
    {
        [SerializeField] private PlayerHp _playerHp;
        [SerializeField] private PlayerAttack _playerAttack;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerAnimation _playerAnimation;

        public bool IsDead { get; private set; }

        private void OnEnable()
        {
            _playerHp.OnHpChanged += CheckDeath;
        }

        private void OnDisable()
        {
            _playerHp.OnHpChanged -= CheckDeath;
        }

        private void CheckDeath(int hp)
        {
            if (hp > 0)
            {
                return;
            }

            _playerHp.OnHpChanged -= CheckDeath;
            
            _playerAnimation.PlayDeath();
            _playerAttack.enabled = false;
            _playerMovement.enabled = false;


            StartCoroutine(ReloadScene());
        }

        private IEnumerator ReloadScene()
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}