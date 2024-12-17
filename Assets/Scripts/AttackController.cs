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
        foreach (Collider2D enemyGameObject in enemy) 
        {
            MonsterHealth monsterHealth = enemyGameObject.GetComponent<MonsterHealth>();
            if (monsterHealth != null)
            {
                monsterHealth.health -= damage; 
                Debug.Log($"Hit monster: {enemyGameObject.name}, Remaining Health: {monsterHealth.health}");
            }

            
            BossHealth bossHealth = enemyGameObject.GetComponent<BossHealth>();
            if (bossHealth != null)
            {
                bossHealth.health -= damage; 
                Debug.Log($"Hit boss: {enemyGameObject.name}, Remaining Health: {bossHealth.health}");
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }
}
