using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MonsterHealth : MonoBehaviour
{
    public float health;
    public float currentHealth;
    public float maxHealth;
    public Animator animator;
    public Collider2D myCollider;

    public MonsterMovement monsterMovement;
    private bool isDead = false;

    [SerializeField] private Image heathBarFill;
    void Start()
    {
        animator=GetComponent<Animator>();
        currentHealth= health;
        maxHealth= health;
        if (monsterMovement == null)
        {
            monsterMovement = FindObjectOfType<MonsterMovement>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return; 

        if (health < currentHealth)
        {
            currentHealth = health;
            animator.SetTrigger("Attacked");
            Debug.Log(health);
        }

        if (health <= 0)
        {
            isDead = true; 
            animator.SetBool("isDead", true);
            Debug.Log("chet");
            myCollider.isTrigger = true;
            Invoke("Disappear", 3f);

            if (monsterMovement != null)
            {
                monsterMovement.SetMovement(false);
            }
        }

        heathBarFill.fillAmount = health/maxHealth;
        
    }
    private void Disappear()
    {
        gameObject.SetActive(false);
    }
}
