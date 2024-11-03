using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UnLockNewLevel();
            //reser level
            //PlayerPrefs.SetInt("UnlockedLevel", 1);
<<<<<<< HEAD
            //PlayerPrefs.Save();

            ResetLevelProgress();
=======
            // PlayerPrefs.Save();

           // ResetLevelProgress();
>>>>>>> 4014effcc988a92c527568d2cd47dbe1e6cf6c2a
            SceneController.instance.NextLevel();
        }
    }
     void UnLockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex",SceneManager.GetActiveScene().buildIndex+1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
    public void ResetLevelProgress()
    {
        PlayerPrefs.SetInt("ReachedIndex", 0); 
        PlayerPrefs.SetInt("UnlockedLevel", 1);
        PlayerPrefs.Save();
        Debug.Log("Progress has been reset to the initial state.");
    }

}

