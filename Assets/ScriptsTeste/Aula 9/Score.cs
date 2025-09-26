using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score I { get; private set; }
    [SerializeField] TMP_Text scoreText;
    int score;

    void Awake()
    {
        if (I != null && I != this) { Destroy(gameObject); return; }
        I = this;
        UpdateUI();
    }

    public void Add(int pts)
    {
        score += pts;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText) scoreText.text = $"Score: {score}";
    }
}