using System.Text;
using UnityEngine;
using UnityEngine.UI; // troque para TMPro se usar TextMeshProUGUI

public class InventoryUI : MonoBehaviour
{
    [Header("Referências")]
    public Inventory inventory; // arraste o Inventory do Player
    public Text listText;       // ou TextMeshProUGUI se preferir (troque os 'using')

    private void OnEnable()
    {
        if (inventory != null) inventory.OnInventoryChanged += Refresh;
        Refresh();
    }

    private void OnDisable()
    {
        if (inventory != null) inventory.OnInventoryChanged -= Refresh;
    }

    public void Refresh()
    {
        if (inventory == null || listText == null) return;

        var sb = new StringBuilder();
        sb.AppendLine("Inventory:");
        foreach (var slot in inventory.slots)
        {
            string name = slot.item != null ? slot.item.displayName : "(null)";
            sb.AppendLine($"- {name} x{slot.count}");
        }

        listText.text = sb.ToString();
    }
}

