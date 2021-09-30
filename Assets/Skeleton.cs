using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public Animator animator;

    public int maxHP = 120;
    int currentHP;

    // Start is called before the first frame update
    void Start()
    {

        currentHP = maxHP;

    }
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        //damaged anim
        animator.SetTrigger("Hurt");

        if (currentHP <= 0)
        {
            Dies();
        }
    }
    void Dies()
    {
        //die anim
        animator.SetBool("Dead", true);
        //Disable enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
