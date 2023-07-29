using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class AdventureScript : MonoBehaviour
{
    public float health, maxHealth = 100f;
    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    public AdventureScript adventurer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        target = GameObject.Find("Adventurer Final Location").transform;
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
        if (GameObject.FindGameObjectWithTag("Dweller"))
        {
            target = GameObject.FindGameObjectWithTag("Dweller").transform;
        }
        else
        {
            target = GameObject.Find("Adventurer Final Location").transform;
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
        if(health <= 0)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
