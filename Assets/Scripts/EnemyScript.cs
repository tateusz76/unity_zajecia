using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public int maxHP = 50;
    int currentHP;
    public float speed = 0.5f;
    Rigidbody2D rb;
    Transform Player;
    Vector2 movement;

    public Animator enemyAnim;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        Player = GameObject.Find("Player").transform;
    }

    public void takingDamage(int damage)
    {
        currentHP  = currentHP - damage;

        enemyAnim.SetTrigger("Hit");

        if(currentHP <= 0)
        {
            Death();
        }
    }
    
    void Update() 
    {
        if(Player)
        {
            Vector2 direction = (Player.position - transform.position).normalized;
            movement = direction;
        }
    }

    void FixedUpdate() 
    {
        if(Player)
        {
            rb.velocity = new Vector2(movement.x, movement.y) * speed;
        }
    }


    void Death()
    {
        enemyAnim.SetBool("isDead", true);
        gameObject.SetActive(false);
        currentHP = maxHP;
    }
}
