using UnityEngine;

namespace TDS.Game.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerAnimation _playerAnimation;
        
        [SerializeField] private float _speed = 4f;

        private Rigidbody2D _rigidbody;
        private Camera _cachedCamera;
        private Transform _cachedTransform;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
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
            Vector3 moveDelta = direction * (_speed);
            _rigidbody.velocity = moveDelta;

            _playerAnimation.SetSpeed(direction.magnitude);
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
