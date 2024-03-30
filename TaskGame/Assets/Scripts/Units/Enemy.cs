using System;
using UnityEngine;

namespace Units
{
    public enum TypeEnemy
    {
        passive,agressive
    }
    [RequireComponent(typeof(Rigidbody2D))]
    public class Enemy :  Unit
    {
        [SerializeField] private TypeEnemy _typeEnemy;
        [SerializeField] private float _viewRadius;
        [SerializeField] private CircleCollider2D _viewCollider;

        private GameObject _playerTarget;
        private Vector2 _movement;

        private void Start()
        {
            SetViewingRadius();
        }

        private void SetViewingRadius()
        {
            _viewCollider.radius = _viewRadius;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _typeEnemy = TypeEnemy.agressive;
                _playerTarget = other.gameObject;
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _typeEnemy = TypeEnemy.agressive;
                _playerTarget = other.gameObject;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _typeEnemy = TypeEnemy.passive;
            }
        }

        private void FixedUpdate()
        {
            if (_typeEnemy == TypeEnemy.agressive)
            {
                EnemyMovement();
            }
        }

        private void EnemyMovement()
        {
            if (_playerTarget!=null)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                    _playerTarget.transform.position, MoveSpeed * Time.deltaTime);
            }
        }
    }
}

