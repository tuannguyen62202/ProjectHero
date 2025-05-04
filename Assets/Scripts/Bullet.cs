using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float fireSpeed = 40f;
    private Rigidbody2D rb;
    private float yBound = 5;
    private float xBound = 15;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name.Contains("Egg"))
        {
            if (transform.position.y > yBound || transform.position.y < -yBound
                || transform.position.x > xBound || transform.position.x < -xBound)
            {
                Destroy(gameObject);
                FindObjectOfType<UIManager>().RemoveEggCount();
            }
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.up * fireSpeed;
    }
}
