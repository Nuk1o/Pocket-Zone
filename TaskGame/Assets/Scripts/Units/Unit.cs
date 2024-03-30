using Data;
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
        [SerializeField] private SerializeController _serializeController;
        public float MoveSpeed
        {
            get { return _movementSpeed; }
        }

        public int Health
        {
            get { return _health; }
        }

        public Vector3 GetPositionUnit()
        {
            return gameObject.transform.position;
        }

        public void SetGameData(GameData gameData)
        {
            _health = gameData.healthValue;
            gameObject.transform.position = 
                new Vector3(gameData.playerPositionX,gameData.playerPositionY,gameData.playerPositionZ);
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
                    _serializeController.DeleteSaveData();
                    SceneLoader _sceneLoader = new SceneLoader();
                    _sceneLoader.ScenLoad("GameOver");
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