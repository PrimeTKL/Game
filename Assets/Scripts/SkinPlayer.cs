using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinPlayer : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    public GameObject playerUI;
    

    private int characterIndex;
    
    public static Transform playerTransform;

    private void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);

        Transform spawnPoint = GameObject.Find("SpawnPoint").transform;
        GameObject player = Instantiate(playerPrefabs[characterIndex], spawnPoint.position, Quaternion.identity);

        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.heartImages = new List<Image>(playerUI.GetComponentsInChildren<Image>());
        }
        playerTransform = player.transform;


    }
    public void ChangePlayer(int newCharacterIndex)
    {
        if (newCharacterIndex >= 0 && newCharacterIndex < playerPrefabs.Length)
        {
            PlayerPrefs.SetInt("SelectedCharacter", newCharacterIndex);
            PlayerPrefs.Save();
            Awake(); 
        }
    }
}
