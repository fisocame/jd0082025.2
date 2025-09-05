using UnityEngine;

public class SlowGround : MonoBehaviour
{
    [Tooltip("0.5 = metade da velocidade; 0.7 = 30% mais lento.")]
    [SerializeField] private float slowMultiplier = 0.5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerMovement2D>();
        if (player != null) player.ModifySpeed(slowMultiplier);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerMovement2D>();
        if (player != null) player.ResetSpeed();
    }
}
