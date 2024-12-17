using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public FinishPoint finishPoint;

    [SerializeField] GameObject victory;

    private void Start()
    {
        if (finishPoint == null)
        {
            finishPoint = FindObjectOfType<FinishPoint>();
        }

    }


    private void Update()
    {
        if(finishPoint.checkFinishPoint==true)
        {
            finishPoint.checkFinishPoint = false;
            
            Invoke("YouWin", 1f);
        }
        
    }
    public void YouWin()
    {
        victory.SetActive(true);
        Time.timeScale = 0;

    }
    public void Home()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1;
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void NextLevel()
    {
        SceneController.instance.NextLevel();
        Time.timeScale = 1;
    }
}
