using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject attackPoint;
    public float radius;
    public LayerMask enemies;
    public float damage;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius,enemies);
        foreach (Collider2D enemyGameobject in enemy) 
        {
            Debug.Log("Hit enemy");
            enemyGameobject.GetComponent<MonsterHealth>().health -= damage;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }
}
