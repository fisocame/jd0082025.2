using UnityEngine;

public class DamageTest : MonoBehaviour
{
    [SerializeField] private PlayerHealth player;

    private void Start()
    {
        player.TakeDamage(10);
        player.coins = 999; // Permitido porque � public
        // player.playerHealth = 999; // N�O permitido
    }
}