using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
    
{
    public Timer timer;
    public PlayerHealth playerHealth;
    AudioManager audioManager;
    
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject desgin;


    
    private void Start()
    {

        if (playerHealth == null)
        {
            playerHealth = FindObjectOfType<PlayerHealth>();
        }
        if (timer == null)
        {
            timer = FindObjectOfType<Timer>();
        }
        if (audioManager == null)
        {
            audioManager = FindObjectOfType<AudioManager>();
        }
    }


    private void Update()
    {

        Debug.Log(playerHealth.isDead);
        
         if( (timer.checkTimer==true||playerHealth.isDead==true)&& !gameOver.activeSelf)
         {
            
              menuGameOver();
              timer.checkTimer = false;
              desgin.SetActive(false);

        }
    }
    public void menuGameOver()
    {
        if (audioManager != null && audioManager.gameOver != null)
        {
            audioManager.PlaySFX(audioManager.gameOver);
        }
        if (gameOver != null)
        {
            gameOver.SetActive(true);
            gameOver.transform.localScale = Vector3.zero;
            gameOver.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack)
                 .OnComplete(() => Time.timeScale = 0);
        }
        

    }
    public void Home()
    {
        desgin.SetActive(true);
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1;
    }
    public void Replay()
    {
        desgin.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
