using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class FallenItem : MonoBehaviour
    {
        [SerializeField] private List<InventoryItem> _items;
        [SerializeField] private SpriteRenderer _itemIco;
        private InventoryItem _dropItem;
        
        public void DroppedEnemyItem(Vector3 position)
        {
            var randomNum = Random.Range(0, _items.Count);
            _dropItem = _items[randomNum];
            _itemIco.sprite = _dropItem.UIIcon;
            gameObject.transform.position = position;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _dropItem.PullupItem();
                Destroy(gameObject);
            }
        }
    }
}