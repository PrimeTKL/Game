using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject attackPointBosss;
    public float radius;
    public LayerMask player;
    public float damageBoss;
    public Animator animator;

    public GameObject set;

    
    public float circle;
    public GameObject attackCircleBoss;

    public BossHealth bossHealth;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (bossHealth == null)
        {
            bossHealth = FindObjectOfType<BossHealth>();
        }
    }
    private void Update()
    {
        RegionAttack();
    }
    public void Attack()
    {
        Collider2D[] pl = Physics2D.OverlapCircleAll(attackPointBosss.transform.position, radius, player);
        foreach (Collider2D enemyGameobject in pl)
        {
            Debug.Log("Hit player");

            enemyGameobject.GetComponent<PlayerHealth>().healthPl -= damageBoss;
        }
    }
    public void RegionAttack()
    {
        Collider2D[] pl = Physics2D.OverlapCircleAll(attackCircleBoss.transform.position, circle, player);

       
        if (pl.Length > 0)
        {
            if(bossHealth.health>=(bossHealth.maxHealth)/2)
            {
                animator.SetBool("Bite_1", true);
                animator.SetBool("Bite_2", false);
                set.SetActive(false);
            }
            else
            {
                animator.SetBool("Bite_2", true);
                animator.SetBool("Bite_1", false);
                set.SetActive(true);
                Debug.Log("a");
            }
            
        }
        else
        {
            set.SetActive(false);
            animator.SetBool("Bite_1", false);
            animator.SetBool("Bite_2", false);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPointBosss.transform.position, radius);
        Gizmos.DrawWireSphere(attackCircleBoss.transform.position, circle);
    }
    
}
