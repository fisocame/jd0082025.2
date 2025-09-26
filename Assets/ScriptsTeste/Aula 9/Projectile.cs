using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float life = 8f; 

    void Awake() => rb = GetComponent<Rigidbody2D>();
    void Start() => Destroy(gameObject, life);

    
    public void Launch(Vector2 initialVelocity)
    {
        rb.linearVelocity = initialVelocity;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        var enemy = col.collider.GetComponent<Enemy>();
        if (enemy) enemy.Hit();

        Destroy(gameObject);
    }
}