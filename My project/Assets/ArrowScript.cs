using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowScript : MonoBehaviour
{
    [SerializeField] float moveSpeed = 15f;
    Rigidbody2D rb;
    Transform target;
    public AdventureScript adventurer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        adventurer = GameObject.FindGameObjectWithTag("Adventurer").GetComponent<AdventureScript>();
    }
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Adventurer").transform;
        Vector3 direction = (target.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Adventurer"))
        {
            adventurer.TakeDamage(5);
        }
        if (!collision.gameObject.CompareTag("Dweller")) {
            Destroy(gameObject);
        }
    }
}

