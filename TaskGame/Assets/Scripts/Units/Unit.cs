using Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Units
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private int _health;
        [SerializeField] private int _maxHealth;
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private FallenItem _dropItemTemplate;
        
        public float MoveSpeed
        {
            get { return _movementSpeed; }
        }

        private void Awake()
        {
            CheckHealth();
        }

        public bool CheckAlive()
        {
            if (_health>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        private void CheckHealth()
        {
            _healthSlider.maxValue = _maxHealth;
            _healthSlider.value = _health;
            _healthText.text = _health.ToString();
        }

        public void DisableUnit(GameObject unit)
        {
            var _dropItem = Instantiate(_dropItemTemplate);
            _dropItem.DroppedEnemyItem(gameObject.transform.position);
            unit.SetActive(false);
        }

        public void TakeDamage(int damageValue)
        {
            if (_health-damageValue<0)
            {
                Debug.Log("Погиб");
                _health = 0;
                CheckHealth();
                if (gameObject.CompareTag("Player"))
                {
                    Debug.Log("Вы проиграли");
                }
            }
            else
            {
                _health -= damageValue;
                CheckHealth();
            }
        }
    }
}