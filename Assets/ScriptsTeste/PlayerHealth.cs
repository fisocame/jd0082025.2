using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int playerHealth = 100; // Vida inicial
    public int coins = 0; // Exemplo de público (para comparar no Inspector)

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        Debug.Log("Vida atual: " + playerHealth);
    }

    public void AddCoin()
    {
        coins++;
        Debug.Log("Moedas: " + coins);
    }
}
