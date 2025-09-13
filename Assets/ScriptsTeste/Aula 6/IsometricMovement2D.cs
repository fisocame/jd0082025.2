using UnityEngine;

public class IsometricMovement2D : MonoBehaviour
{
    [Header("Movimenta��o")]
    [Tooltip("Velocidade em unidades por segundo no plano isom�trico.")]
    public float moveSpeed = 5f;

    [Header("Refer�ncias")]
    public Rigidbody2D rb;
    public Animator animator; // opcional (para Blend Tree/dire��o)

    // Cache de entrada
    private Vector2 rawInput;   // WASD/Setas (antes de converter)
    private Vector2 isoDir;     // dire��o j� convertida para isom�trico

    void Awake()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        // Top-down 2D: sem gravidade e sem rota��o
        rb.gravityScale = 0f;
        rb.freezeRotation = true;
    }

    void Update()
    {

        rawInput = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );


        rawInput = Vector2.ClampMagnitude(rawInput, 1f);


        isoDir = Rotate(rawInput, -45f);


        if (animator != null)
        {
            animator.SetFloat("MoveX", isoDir.x);
            animator.SetFloat("MoveY", isoDir.y);
            animator.SetFloat("Speed", isoDir.sqrMagnitude);
        }
    }

    void FixedUpdate()
    {

        rb.linearVelocity = isoDir * moveSpeed;
    }


    private static Vector2 Rotate(Vector2 v, float degrees)
    {
        float rad = degrees * Mathf.Deg2Rad;
        float s = Mathf.Sin(rad);
        float c = Mathf.Cos(rad);
        return new Vector2(v.x * c - v.y * s,
                           v.x * s + v.y * c);
    }
}

