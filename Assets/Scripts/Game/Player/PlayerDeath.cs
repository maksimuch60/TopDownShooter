using System;
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
        

        private void OnEnable()
        {
            _playerHp.OnLivesEnded += PerformDeath;
        }

        private void OnDisable()
        {
            _playerHp.OnLivesEnded += PerformDeath;
        }

        private void PerformDeath()
        {
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