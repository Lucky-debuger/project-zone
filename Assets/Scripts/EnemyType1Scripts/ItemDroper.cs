using UnityEngine;

public class ItemDroper : MonoBehaviour
{
    [SerializeField] private GameObject itemToDrop;
    [SerializeField] private HealthSystem healthSystem;

    public void Start()
    {
        healthSystem.OnDied += DropItem;
    }

    private void DropItem()
    {
        Instantiate(itemToDrop, transform.position, Quaternion.identity);
    }    
}
