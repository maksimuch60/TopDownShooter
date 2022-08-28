using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerAnimation _playerAnimation;
        
        [SerializeField] private float _speed = 4f;

        private Camera _cachedCamera;
        private Transform _cachedTransform;

        private void Awake()
        {
            _cachedCamera = Camera.main;
            _cachedTransform = transform;
        }

        private void Update()
        {
            Move();
            Rotate();
        }

        private void Move()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 direction = new(horizontal, vertical);
            Vector3 moveDelta = direction * (_speed * Time.deltaTime);
            transform.position += moveDelta;

            _playerAnimation.SetSpeed((direction * _speed).magnitude);
        }

        private void Rotate()
        {
            Vector3 mousePositionInPixels = Input.mousePosition;
            Vector3 mousePositionInUnits = _cachedCamera.ScreenToWorldPoint(mousePositionInPixels);

            Vector2 direction = mousePositionInUnits - _cachedTransform.position;
            _cachedTransform.up = direction;
        }
    }
}
