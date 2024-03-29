using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameField;
    [SerializeField] private Image _icon;
    public void Render(IItem item)
    {
        if (item.CountItems>1)
        {
            _nameField.text = $"{item.Name}\t{item.CountItems}";
        }
        else
        {
            _nameField.text = $"{item.Name}";
        }
        _icon.sprite = item.UIIcon;
    }
}