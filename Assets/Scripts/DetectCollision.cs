using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private float maxHealth = 100f;
    private float currentHealth;
    private SpriteRenderer spriteRenderer;
    private int eggHitCount  = 0;
    private Spawner spawner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spawner = FindObjectOfType<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            HandleEggCollision();
            Destroy(other.gameObject);
            FindObjectOfType<UIManager>().RemoveEggCount();

        }
        else if (other.CompareTag("Hero")) {
            DestroyEnemy();
            FindObjectOfType<UIManager>().AddTouchedEnemy();
        }
    }
    void DestroyEnemy()
    {
        spawner.EnemyDestroyed();
        Destroy(gameObject);
    }
    void HandleEggCollision()
    {
        eggHitCount++;
        float damage = maxHealth * 0.2f;
        currentHealth -= damage;

        Color color = spriteRenderer.color;
        color.a *= 0.8f;
        spriteRenderer.color = color;
        if (eggHitCount >= 4 || currentHealth <= 0) {
            DestroyEnemy();
            FindObjectOfType<UIManager>().AddEnemiesDestroyed();
        }
    }
}
