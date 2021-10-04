using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;

    public float moveSpeed = 5f;
    
    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    
    // FixedUpdate is called once per set number of frames
    void FixedUpdate()
    {
        MoveEnemy(movement);
    }

    // Moving the enemy towards the player as calculated using Update()
    void MoveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    // On Trigger is called upon a certain trigger
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            print("Player hit the Enemy. How rude!");
        }

        //Enemy destroyed by Projectiles only, not by other collisions.
        if(collider.CompareTag("Projectile"))
        {
            print("The enemy was struck and killed by an ice knife!");
            Destroy(gameObject,0.5f);
        }
    }
}
