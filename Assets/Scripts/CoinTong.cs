using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CoinTong : MonoBehaviour
{
    public TextMeshProUGUI coinTong;

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        UpdateCoinUI();
    }

    private void OnEnable()
    {
        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
       
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Update()
    {
       
        UpdateCoinUI();
    }

    private void UpdateCoinUI()
    {
       
        int savedCoinTong = PlayerPrefs.GetInt("PlayerCoinTong", 0);

        
        if (coinTong == null)
        {
            coinTong = GameObject.Find("CoinTong").GetComponent<TextMeshProUGUI>();
        }

        
        coinTong.text = " " + savedCoinTong.ToString();
    }
}
