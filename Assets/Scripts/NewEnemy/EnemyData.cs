using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Enemy/Enemy Data")] // Что такое атрибуты? 
public class EnemyData : ScriptableObject
{
    [Header("General settings")]
    public string enemyName;
    public int health = 100;
    public float detectionRange = 5f;
    public float attackRange = 2f;
    public float moveSpeed = 3f;
    
    [Header("Attack")]
    public int damage = 10;
    public float attackCooldown = 1f;
    
    [Header("Drop")]
    public ItemScriptableObject item;
}