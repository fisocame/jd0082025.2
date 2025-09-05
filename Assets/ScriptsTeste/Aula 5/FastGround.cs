using UnityEngine;

public class FastGround : MonoBehaviour
{
    [Tooltip("2 = dobro da velocidade; 1.5 = 50% mais rápido.")]
    [SerializeField] private float speedMultiplier = 2f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerMovement2D>();
        if (player != null) player.ModifySpeed(speedMultiplier);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerMovement2D>();
        if (player != null) player.ResetSpeed();
    }
}