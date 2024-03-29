using System.Collections.Generic;
using Items;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<InventoryItem> _items;
    [SerializeField] private InventoryCell _inventoryCellTemplate;
    [SerializeField] private Transform _container;
    [SerializeField] private GameObject _dropItemPanel;

    private Button _confirm, _cancel;
    private void OnEnable()
    {
        Render(_items);
    }

    public void Render(List<InventoryItem> items)
    {
        foreach (Transform child in _container)
        {
            Destroy(child.gameObject);
        }
        items.ForEach(item =>
        {
            if (item.IsPositive())
            {
                var cell = Instantiate(_inventoryCellTemplate, _container);
                cell.Render(item);
                cell.GetComponent<Button>().onClick.AddListener(delegate { OpenDropItemPanel(item); });
            }
        });
    }

    private void OpenDropItemPanel(InventoryItem item)
    {
        Debug.Log($"Debug: {item}");
        _dropItemPanel.SetActive(true);
        _confirm = _dropItemPanel.transform.GetChild(1).GetComponent<Button>();
        _cancel = _dropItemPanel.transform.GetChild(2).GetComponent<Button>();
        _confirm.onClick.AddListener(delegate { CheckDropItem(item); });
        _cancel.onClick.AddListener(delegate { CloseDropItemPanel(); });
    }

    private void CloseDropItemPanel()
    {
        _confirm.onClick.RemoveAllListeners();
        _cancel.onClick.RemoveAllListeners();
        _dropItemPanel.SetActive(false);
    }

    private void CheckDropItem(InventoryItem item)
    {
        if (item.DropItem())
        {
            Debug.Log("Предмет успешно удалён");
            CloseDropItemPanel();
            Render(_items);
        }
        else
        {
            Debug.Log("Нет предметов для удаления");
            CloseDropItemPanel();
        }
    }
}
