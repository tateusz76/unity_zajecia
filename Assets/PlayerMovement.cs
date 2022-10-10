using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 4f;
    public Rigidbody2D rigidBody;
    Vector2 movement;
    public Animator animator;

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
    }

    
}
