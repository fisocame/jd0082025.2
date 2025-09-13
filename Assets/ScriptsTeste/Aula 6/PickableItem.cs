using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PickableItem : MonoBehaviour
{
    [Header("Dados do Item")]
    public ItemData data;
    [Min(1)] public int amount = 1;

    [Header("Feedback (opcional)")]
    public AudioSource pickupSfx; // arraste um AudioSource com um áudio curto

    private void Reset()
    {

        var col = GetComponent<Collider2D>();
        col.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        var inventory = other.GetComponent<Inventory>();
        if (inventory == null) return;

        int remainder = inventory.AddItem(data, amount);


        if (remainder == 0)
        {
            if (pickupSfx != null) pickupSfx.Play();

            Destroy(gameObject);
        }
        else
        {

            amount = remainder;
        }
    }
}

