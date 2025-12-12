using TMPro;
using UnityEngine;

public class FPSShow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;

    private void Update()
    {
        string FPS = (Mathf.RoundToInt(1.0f/Time.deltaTime)).ToString();
        textMeshPro.text = $"FPS: {FPS}";
    }
}
