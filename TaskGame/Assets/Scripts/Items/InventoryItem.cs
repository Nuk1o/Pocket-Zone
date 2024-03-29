using UnityEngine;

namespace Items
{
    [CreateAssetMenu (menuName = "Item")]
    public class InventoryItem : ScriptableObject,IItem
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _uiIcon;
        [SerializeField] private int _countItems;
        public string Name => _name;
        public Sprite UIIcon => _uiIcon;
        public int CountItems => _countItems;

        public bool DropItem()
        {
            if (_countItems>0)
            {
                _countItems--;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PullupItem()
        {
            _countItems++;
        }

        public bool IsPositive()
        {
            return _countItems>0 ? true:false;
        }
    }
}