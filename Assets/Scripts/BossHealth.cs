using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public float health;
    public float currentHealth;
    public float maxHealth;
    public Animator animator;
    public Collider2D myCollider;

    public BossMovement bossMovement;
    private bool isDead = false;

    [SerializeField] private Image heathBarFill;
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = health;
        maxHealth = health;
        if (bossMovement == null)
        {
            bossMovement = FindObjectOfType<BossMovement>();
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

            if (bossMovement != null)
            {
                bossMovement.SetMovement(false);
            }
        }

        heathBarFill.fillAmount = health / maxHealth;

    }
    private void Disappear()
    {
        gameObject.SetActive(false);
    }
}
