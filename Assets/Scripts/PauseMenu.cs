using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public void Pause()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
            pauseMenu.transform.localScale = Vector3.zero;
            pauseMenu.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack)
                 .OnComplete(() => Time.timeScale = 0); 
        }
    }
    public void Home()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1;
    }
    public void Continue()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
