using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float rotateSpeed = 0.5f;
    private Rigidbody2D rb;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;


    private float fireRate = 0.2f;
    private float nextFire = 0f;
    private bool useMouseControl;
    Vector2 mousePos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        useMouseControl = true;  // Default is mouse control
    }

    void Update()
    {
        UpdateMode();
        ProcessBulletSpawn();

        if (useMouseControl)
        {
            MouseControl();
            transform.position = mousePos;
            UpdateDirectionAndSpeed();
        }
        else
        {
            UpdateDirectionAndSpeed();  // Use speed & rotation control
        }
    }

    private void FixedUpdate()
    {
        if (!useMouseControl)
        {
            rb.velocity = transform.up * moveSpeed;  // 
        }
        else
        {
            rb.velocity = Vector2.zero;  // Stop physics velocity when mouse control
        }
    }

    private void ProcessBulletSpawn()
    {
        if ((Input.GetKey(KeyCode.Space)) && Time.time > nextFire)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            
            nextFire = Time.time + fireRate;
            FindObjectOfType<UIManager>().AddEggCount();
        }
       
    }

    void UpdateDirectionAndSpeed()
    {
        // Change Speed
        if (Input.GetKey(KeyCode.W))
        {
            moveSpeed += 0.1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveSpeed = Mathf.Max(0f, moveSpeed - 0.1f);
        }

        // Change direction
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, rotateSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -rotateSpeed);
        }
    }

    void MouseControl()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       
    }

    void UpdateMode()
    {
        // Toggle control mode with key 'M'
        if (Input.GetKeyDown(KeyCode.M))
        {
            useMouseControl = !useMouseControl;
            Debug.Log("Control mode: " + (useMouseControl ? "Mouse" : "Keyboard"));
   
        }
        FindObjectOfType<UIManager>().SetControlMode(useMouseControl);
    }
}
