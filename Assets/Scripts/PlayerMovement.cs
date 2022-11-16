using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 4f;
    public Rigidbody2D rigidBody;
    Vector2 movement;
    public Animator animator;
    public int playerMaxHP = 100;
    public int playerCurrentHP;

    private int playerLevel = 1;
    public int playerEXP = 0;

    public HPBarController bar;
    public PlayerAttack attack;


    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHP = playerMaxHP;
        bar.setMaxHP(playerCurrentHP);
    }

    // Update is called once per frame
    void Update()
    {
        //Wyłapywanie kierunków ruchu
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("playerSpeed", movement.sqrMagnitude);
    }

    void FixedUpdate() //nie jest callowane co frame tylko kilka razy na sekundę
    {
        //Poruszanie gracza
        rigidBody.MovePosition(rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (movement.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (movement.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        } 

        if (playerEXP >= playerLevel * 20)
        {
            Debug.Log("LEVEL UP");
            playerLevel += 1;
            playerEXP = 0;
            playerMaxHP += 20;
            attack.playerDamage += 2;
            playerCurrentHP = playerMaxHP;
            bar.setMaxHP(playerCurrentHP);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Enemy")
        {
            playerCurrentHP -= 20;
            bar.setHP(playerCurrentHP);
            Debug.Log(playerCurrentHP);

            if(playerCurrentHP <= 0) 
            {
                Debug.Log("Dead");
                SceneManager.LoadScene("Scenes/MenuScene", LoadSceneMode.Single);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Heal")
        {
            playerCurrentHP += 50;
            if(playerCurrentHP > playerMaxHP)
            {
                playerCurrentHP = playerMaxHP;
            }
            bar.setHP(playerCurrentHP);
            col.gameObject.SetActive(false);
            
        }
    }    
}
