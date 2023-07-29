using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DungeonScript : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 5f;
    [SerializeField] float moveSpeed = 15f;
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
        health = maxHealth;
        target = GameObject.FindGameObjectWithTag("Adventurer").transform;
        adventurer = GameObject.FindGameObjectWithTag("Adventurer").GetComponent<AdventureScript>();
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
    }
    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
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
        if(collision.gameObject.tag == ("Adventurer"))
        {
            TakeDamage(1);
            adventurer.TakeDamage(10);
        }
    }
}
