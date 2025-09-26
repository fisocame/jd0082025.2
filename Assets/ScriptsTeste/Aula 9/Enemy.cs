using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void Hit()
    {
        Score.I?.Add(100);
        Destroy(gameObject);
    }
}