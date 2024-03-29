using Units;
using UnityEngine;

namespace PlayerController
{
    [RequireComponent(typeof(Rigidbody2D),typeof(BoxCollider2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private FixedJoystick _joystick;

        private float _moveSpeed;

        private void Awake()
        {
            _moveSpeed = _player.MoveSpeed;
        }

        private void FixedUpdate()
        {
            _rigidbody2D.velocity = new Vector2(_joystick.Horizontal * _moveSpeed, _joystick.Vertical * _moveSpeed);
        }
    }
}