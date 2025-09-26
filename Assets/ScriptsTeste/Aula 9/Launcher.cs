using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Launcher : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] Transform muzzle;
    [SerializeField] GameObject projectilePrefab;

    [Header("UI")]
    [SerializeField] TMP_InputField angleInput;
    [SerializeField] TMP_InputField speedInput;
    [SerializeField] Button launchButton;

    const float DEG2RAD = Mathf.Deg2Rad;

    void Reset()
    {
        
        angleInput = FindObjectOfType<TMP_InputField>();
    }

    void Start()
    {
        if (launchButton) launchButton.onClick.AddListener(HandleLaunchClick);
    }

    void HandleLaunchClick()
    {
        if (!muzzle || !projectilePrefab) return;

        
        if (angleInput == null || speedInput == null) return;

        
        float angleDeg = TryParse(angleInput.text, 45f);
        float speed    = TryParse(speedInput.text, 10f);

        
        angleDeg = Mathf.Clamp(angleDeg, 0f, 90f);
        speed    = Mathf.Clamp(speed, 0.1f, 50f);

        
        float rad = angleDeg * DEG2RAD;
        Vector2 v0 = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)) * speed;

        
        var go = Instantiate(projectilePrefab, muzzle.position, Quaternion.identity);
        var proj = go.GetComponent<Projectile>();
        proj.Launch(v0);
    }

    float TryParse(string s, float fallback)
    {
        return float.TryParse(s.Replace(",", "."), out float v) ? v : fallback;
    }
}