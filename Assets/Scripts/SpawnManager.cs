using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnEnemy;
    [SerializeField] private Transform[] spawnPoint;
    [SerializeField] private bool isActive;
    
    private float spawnerInterval;

    private int randEnemy;
    private int randPoint;

    public float startSpawnerInterval;
    public int totalNumberEnemies;
    public int numberEnemiesOnScene;

    void Start()
    {
        spawnerInterval = startSpawnerInterval;
    }

    void Update()
    {
        if (!isActive) return;

        if (spawnerInterval <= 0 && numberEnemiesOnScene < totalNumberEnemies)
        {
            randEnemy = Random.Range(0, spawnEnemy.Length);
            randPoint = Random.Range(0, spawnPoint.Length);

            GameObject enemy = Instantiate(spawnEnemy[randEnemy], spawnPoint[randPoint].transform.position, Quaternion.identity);
            enemy.GetComponent<HealthSystem>().OnDied += () => numberEnemiesOnScene--;

            spawnerInterval = startSpawnerInterval;
            numberEnemiesOnScene++;
        }
        else
        {
            spawnerInterval -= Time.deltaTime;
        }
    }

}
