using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float healthPl;
    public float currentHealthPl;

    public Animator animator;
    public MonsterMovement monsterMovement;

    public List<Image> heartImages;  
    public Sprite fullHeart;        
    public Sprite halfHeart;         
    public Sprite emptyHeart;     

    private bool isDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealthPl = healthPl;

        
        foreach (Image heart in heartImages)
        {
            heart.sprite = fullHeart;
        }

        if (monsterMovement == null)
        {
            monsterMovement = FindObjectOfType<MonsterMovement>();
        }
    }

    void Update()
    {
        if (healthPl < currentHealthPl)
        {
            currentHealthPl = healthPl;
            animator.SetTrigger("Attacked");
            UpdateHearts();
        }

        if (healthPl <= 0 && !isDead)
        {
            isDead = true;
            animator.SetBool("isDead", true);
            monsterMovement.SetMovement(false);
        }
    }

    void UpdateHearts()
    {
        float healthRemaining = healthPl;
        for (int i = 0; i < heartImages.Count; i++)
        {
            if (healthRemaining >= 10)
            {
                heartImages[i].sprite = fullHeart;
                healthRemaining -= 10;
            }
            else if (healthRemaining >= 5)
            {
                heartImages[i].sprite = halfHeart;
                healthRemaining -= 5;
            }
            else
            {
                heartImages[i].sprite = emptyHeart; 
            }
        }
    }
}
