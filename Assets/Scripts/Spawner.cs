using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int numberToSpawn = 10;
    [SerializeField] private GameObject enemy;
    private int spawnedEnemy;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnEnemy()
    {
        int attemps = 0;
        int maxAttemps = numberToSpawn * 10;
        while (attemps < maxAttemps && spawnedEnemy < numberToSpawn)
        {

            Vector3 objPosition = new Vector3(Random.Range(-7f, 7f), Random.Range(-4f, 4f), 0);
            // ensures new object is spawned far enough away
            if ((objPosition - transform.position).magnitude < 3)
            {
                attemps++;
                continue;
            }
            else
            {
                    
                Instantiate(enemy, objPosition, Quaternion.identity);
                spawnedEnemy++;
                attemps++;
            }
        }
        FindObjectOfType<UIManager>().SetEnemyCount(spawnedEnemy);

    }
    public void EnemyDestroyed()
    {
        spawnedEnemy--;
        SpawnEnemy();
    }

}