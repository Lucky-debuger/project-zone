using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.position;
    }

    private Vector3 GetRoamingPosition()
    {
        Vector3 result = startingPosition + GetRandomDir() * Random.Range(10f, 70f);
        Debug.Log(result);
        return result;
        
    }

    private Vector3 GetRandomDir()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1, 1f)).normalized;
    }
}
