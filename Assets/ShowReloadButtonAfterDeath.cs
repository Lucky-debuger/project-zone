using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowReloadButtonAfterDeath : MonoBehaviour
{
    [SerializeField] Player player;

    private void Start()
    {
        player.GetComponent<HealthSystem>().OnDied += ToggleInventoryActivity;
        ToggleInventoryActivity();
    }

    private void ToggleInventoryActivity() => gameObject.SetActive(!gameObject.activeSelf);
}
