using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    private Vector3 target;

    void Start()
    {
        target = pointB.position;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position, // origem
            target, // destino
            speed * Time.deltaTime // passo
        );

        // condição ? valorSeVerdadeiro : valorSeFalso; 
        // ? == operador ternário

        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            target = (target == pointA.position) ? pointB.position : pointA.position;
        }

    }

}

