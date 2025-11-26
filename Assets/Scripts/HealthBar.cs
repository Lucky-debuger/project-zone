using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] Slider slider;
    [SerializeField] HealthSystem healthSystem;

    private void OnEnable()
    {
        if (healthSystem != null)
        {
            healthSystem.OnHealthPointsChanged += SetHealth;
        }
    }

    private void OnDisable()
    {
        healthSystem.OnHealthPointsChanged -= SetHealth;
    }

    private void SetHealth(float health)
    {
        if (slider != null)
        {
            slider.value = health;
        }
    }
}
