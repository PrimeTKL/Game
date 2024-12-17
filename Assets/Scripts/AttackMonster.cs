using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMonster : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject attackPointMonster;
    public float radius;
    public LayerMask player;
    public float damageMonster;

    public MonsterMovement monsterMovement;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (monsterMovement == null)
        {
            monsterMovement = FindObjectOfType<MonsterMovement>();
        }
    }

    public void Attack()
    {
        Collider2D[] pl = Physics2D.OverlapCircleAll(attackPointMonster.transform.position, radius, player);
        foreach (Collider2D enemyGameobject in pl)
        {
            Debug.Log("Hit player");
            
            enemyGameobject.GetComponent<PlayerHealth>().healthPl -= damageMonster;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPointMonster.transform.position, radius);
    }
}
