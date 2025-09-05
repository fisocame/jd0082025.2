using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    [Header("Velocidade")]
    [Tooltip("Velocidade padrão (base) do personagem.")]
    public float moveSpeed = 5f;
    private float currentSpeed;         // essa velocidade vai ser modificada pelo chão

    [Header("Pulo")]
    public float jumpForce = 7f;
    public Transform groundCheck;       // lembrem de botar embaixo do pé pra não sair pulando por aí
    public float groundCheckRadius = 0.2f;
    public LayerMask groundMask;

    [Header("Referências")]
    public Rigidbody2D rb;

    // cache de entrada
    private float inputX;
    private bool jumpPressed;
    private bool isGrounded;

    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        currentSpeed = moveSpeed; // começa com a velocidade base
    }

    void Update()
    {

        inputX = Input.GetAxisRaw("Horizontal");


        if (Input.GetButtonDown("Jump"))
            jumpPressed = true;
    }

    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundMask
        );

        rb.linearVelocity = new Vector2(inputX * currentSpeed, rb.linearVelocity.y);

        if (jumpPressed && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        jumpPressed = false;
    }

    public void ModifySpeed(float multiplier)
    {
        currentSpeed = moveSpeed * multiplier;
    }

    public void ResetSpeed()
    {
        currentSpeed = moveSpeed;
    }
}
