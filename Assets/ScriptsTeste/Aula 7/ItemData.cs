using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item Data", fileName = "NewItemData")]
public class ItemData : ScriptableObject
{
    [Header("Identifica��o")]
    public string itemId;          // um ID �nico ("potion_small", "coin", etc.)
    public string displayName;     // nome vis�vel

    [Header("Visual")]
    public Sprite icon;            // �cone para UI

    [Header("Empilhamento")]
    public bool stackable = true;  // pode acumular?
    [Min(1)] public int maxStack = 99;
}

