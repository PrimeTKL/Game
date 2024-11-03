using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("da cham");
            gameObject.SetActive(false);
        }
    }
}
