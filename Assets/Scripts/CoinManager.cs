using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coinCount;
    public Text coinText;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (coinText == null)
        {
            coinText = GameObject.Find("CoinText").GetComponent<Text>();
        }
    }

    private void Update()
    {
        coinText.text= ": "+coinCount.ToString();
    }

}
