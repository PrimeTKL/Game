using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public DoorWithKey linkedDoor;

    private bool isPickedUp = false;
    private Transform playerTransform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isPickedUp)
        {
            isPickedUp = true;
            playerTransform = collision.transform;
            transform.SetParent(playerTransform); 
            Debug.Log("Player picked up the key.");
        }
    }

    void Update()
    {
        if (isPickedUp && playerTransform != null)
        {
            transform.position = playerTransform.position + new Vector3(0.5f, 0.5f, 0f);
        }
    }

    public bool IsPickedUp()
    {
        return isPickedUp;
    }

    public void ConsumeKey()
    {
        Destroy(gameObject);
    }
}
