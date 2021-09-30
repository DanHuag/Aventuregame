using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    private int currentAttack = 0;
    private float timeSinceAttack = 0.0f;
    public Transform AttackPoint;  
    public float attackRange = 0.6f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;
    public Transform FirePoint;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.A))
        {
            Attack();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            fire();
        }*/
        timeSinceAttack += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.A) && timeSinceAttack > 0.25f)
        {
            Attack();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            fire();
        }
    }

    void Attack()
    {
         //attack anim
         //animator.SetTrigger("Attack");
        currentAttack++;

        if (currentAttack > 3)
            currentAttack = 1;

        if (timeSinceAttack > 1.0f)
            currentAttack = 1;

        animator.SetTrigger("Attack" + currentAttack);

        timeSinceAttack = 0.0f;
        //detect enemy
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);

        /*void flipAttack()
        {
            Instantiate(AttackPoint, AttackPoint.position, AttackPoint.rotation);
        }*/

         //damage enemy
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void fire()
    {
        animator.SetTrigger("kame");
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);       
    }

    void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }

}

