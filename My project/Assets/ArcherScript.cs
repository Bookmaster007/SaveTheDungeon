using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ArcherScript : MonoBehaviour
{    
    [SerializeField] float health, maxHealth = 3f;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] GameObject arrow;
    [SerializeField] Transform firePoint;
    float timer = 0;
    [SerializeField] float SpawnTime = 52; 
    Rigidbody2D rb;
    Transform target;
    public AdventureScript adventurer;
    Vector2 moveDirection;
    public float damage;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(arrow, firePoint.position, firePoint.rotation);
        health = maxHealth;
        target = GameObject.FindGameObjectWithTag("Adventurer").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDirection = direction;
        }
        if(timer >= SpawnTime)
        {
            Instantiate(arrow, firePoint.position, firePoint.rotation);
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = moveDirection*0;
    }
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Adventurer"))
        {
            TakeDamage(1);

        }
    }
}
