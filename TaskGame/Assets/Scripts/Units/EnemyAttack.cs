using System.Collections;
using Units;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int _damageValue;
    [SerializeField] private float _attackRadius;
    [SerializeField] private CircleCollider2D _attackCollider2D;
    private Player _player;
    
    private void Start()
    {
        SetAttackRadius();
    }

    private void SetAttackRadius()
    {
        _attackCollider2D.radius = _attackRadius;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _player = other.gameObject.GetComponent<Player>();
            StartCoroutine(AttackCoroutine());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopAllCoroutines();
        }
    }
    
    IEnumerator AttackCoroutine()
    {
        while (true)
        {
            _player.TakeDamage(_damageValue);
            yield return new WaitForSeconds(1);
        }
    }
}