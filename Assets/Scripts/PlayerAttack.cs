using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    public Transform attackHitbox;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    public int playerDamage = 20;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            Attack();
        }
    }  

    void Attack()
    {
        animator.SetTrigger("isAttacking");

        //funkcja tworzy okrąg, który wykrywa nam trafianych przeciwników (hitboxy robi)
        Collider2D[] hittableEnemies = Physics2D.OverlapCircleAll(attackHitbox.position, attackRange, enemyLayer);

        foreach(Collider2D enemy in hittableEnemies)
        {
            Debug.Log("Hit");
            enemy.GetComponent<EnemyScript>().takingDamage(playerDamage);
        }
    } 

    void OnDrawGizmosSelected()
    {
        if(attackHitbox == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackHitbox.position, attackRange);
    }
}
