using System;
using System.Collections;
using TMPro;
using Units;
using UnityEngine;
using UnityEngine.UI;

namespace Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private int _ammo;
        [SerializeField] private int _maxAmmo;
        [SerializeField] private int _damageValue;
        [SerializeField] private float _speedAttack;
        [SerializeField] private SpriteRenderer _gunSprite;
        [SerializeField] private TMP_Text _ammoText;
        [SerializeField] private float _attackRadius;
        [SerializeField] private CircleCollider2D _attackCollider2D;
        [SerializeField] private Button _shootBtn;

        private bool _isAttack;

        private Enemy _enemy;
        private void Start()
        {
            _isAttack = false;
            SetAttackRadius();
            SetTextAmmo();
        }

        private void OnEnable()
        {
            _shootBtn.onClick.AddListener(delegate { TakeShoot(); });
        }

        private void OnDisable()
        {
            _shootBtn.onClick.RemoveAllListeners();
        }

        private void TakeShoot()
        {
            if (_ammo>1)
            {
                _ammo -= 1;
                SetTextAmmo();
            }
            else
            {
                _shootBtn.interactable = false;
                ReloadWeapon();
            }
        }

        private void SetAttackRadius()
        {
            _attackCollider2D.radius = _attackRadius;
        }

        private void SetTextAmmo()
        {
            _ammoText.text = _ammo.ToString();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy")&&!_isAttack)
            {
                _enemy = other.gameObject.GetComponent<Enemy>();
                AttackOfEnemy();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy")&&_isAttack)
            {
                _enemy = null;
                AttackOfEnemy();
            }
        }

        private void AttackOfEnemy()
        {
            if (_enemy!=null&&!_isAttack)
            {
                _isAttack = true;
                StartCoroutine(AttackCoroutine());
            }
            else
            {
                _isAttack = false;
                StopCoroutine(AttackCoroutine());
            }
        }

        private void ReloadWeapon()
        {
            _ammo = _maxAmmo;
            SetTextAmmo();
            _shootBtn.interactable = true;
        }

        IEnumerator AttackCoroutine()
        {
            while (true)
            {
                if (_enemy!=null)
                {
                    if (!_enemy.CheckAlive())
                    {
                        _enemy.DisableUnit(_enemy.gameObject);
                        _enemy = null;
                        break;
                    }
                    if (_ammo>0)
                    {
                        _ammo -= 1;
                        _enemy.TakeDamage(_damageValue);
                        SetTextAmmo();
                        yield return new WaitForSeconds(_speedAttack);
                    }
                    else
                    {
                        _shootBtn.interactable = false;
                        yield return new WaitForSeconds(2);
                        ReloadWeapon();
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}