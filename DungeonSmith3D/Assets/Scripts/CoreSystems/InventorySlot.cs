using DiceGame.Scripts.CoreSystems;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] int SlotIndex;
    [SerializeField] GameObject ToolTipPopup;
    [SerializeField] TextMeshProUGUI Name;
    [SerializeField] TextMeshProUGUI Description;
    [SerializeField] Image Icon;
    [SerializeField] Image SlotIcon;
    [SerializeField] UnityEvent<Item> Selected;
    public void CombatSelect()
    {
        Selected.Invoke(_item);
    }

    private Item _item;
    public void Clicked()
    {
       

        if (_item == null)
        {
            ToolTipPopup.SetActive(false);
            return;
        }
        else
            ToolTipPopup.SetActive(true);
            
        Name.text = _item.Stats.ThisItemName;
        Description.text = _item.Stats.Description;
        Icon.sprite = _item.Stats.Icon;
      
    }

    private void OnEnable()
    {
        _item = GameManager.Instance.GamePlayer.PlayerInventory.GetInventory()[SlotIndex];

        if (_item != null)
            SlotIcon.sprite = _item.Stats.Icon;
    }

}
