using DiceGame.Scripts.CoreSystems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] int SlotIndex;
    [SerializeField] GameObject ToolTipPopup;
    [SerializeField] TextMeshProUGUI Name;
    [SerializeField] TextMeshProUGUI Description;
    [SerializeField] Image Icon;
    [SerializeField] Image SlotIcon;

   
    private Item _item;
    public void Clicked()
    {
       

        if (_item == null) return;


        ToolTipPopup.SetActive(!ToolTipPopup.activeSelf);
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
