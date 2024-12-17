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
    AudioManager audioManager;

    public List<Image> heartImages;  
    public Sprite fullHeart;        
    public Sprite halfHeart;         
    public Sprite emptyHeart;     

    public bool isDead = false;

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
        if (audioManager == null)
        {
            audioManager = FindObjectOfType<AudioManager>();
        }
    }

    void Update()
    {
        if (healthPl < currentHealthPl)
        {
            currentHealthPl = healthPl;
            if (healthPl>0&&audioManager != null && audioManager.gameOver != null)
            {
                audioManager.PlaySFX(audioManager.takeDamge);
            }
            animator.SetTrigger("Attacked");
            UpdateHearts();
        }

        if (healthPl <= 0 && !isDead)
        {
            
            animator.SetBool("isDead", true);
            monsterMovement.SetMovement(false);
            
            Invoke("Dead", 2f);

            
        }
    }
    public void Dead()
    {
        isDead = true;
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
