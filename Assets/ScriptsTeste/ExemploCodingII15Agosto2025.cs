using UnityEngine;

public class ExemploCodingII : MonoBehaviour
{
    // ERRADO

    public int vidaDoPlayer;

    // CERTO

    [SerializeField] private int playerHealth;


}


