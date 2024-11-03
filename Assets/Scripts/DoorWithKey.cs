using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWithKey : MonoBehaviour
{
    public Transform door;
    public float openDistance = 3f;
    public float openDuration = 1f;
    public float waitTime = 2f;
    public KeyPickup requiredKey;

    private Vector3 doorOriginalPosition;
    private bool isOpened = false;

    void Start()
    {
        if (door != null)
        {
            doorOriginalPosition = door.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player has collided with the door."); 

        if (collision.collider.CompareTag("Player") && !isOpened)
        {
            KeyPickup key = collision.collider.GetComponentInChildren<KeyPickup>();
            if (key != null)
            {
                Debug.Log("Found a KeyPickup on the player.");
                Debug.Log("requiredKey: " + requiredKey.GetInstanceID());
                Debug.Log("key: " + key.GetInstanceID());

                if (key == requiredKey && key.IsPickedUp())
                {
                    Debug.Log("Player has the required key. Opening the door."); 
                    isOpened = true;
                    StartCoroutine(OpenDoor());
                    key.ConsumeKey();
                }
                else
                {
                    Debug.Log("The key on the player does not match the required key or has not been picked up.");
                }
            }
            else
            {
                Debug.Log("No KeyPickup found on the player.");
            }

        }
    }


    private IEnumerator OpenDoor()
    {
        Vector3 openPosition = doorOriginalPosition + Vector3.up * openDistance;

        float elapsedTime = 0f;
        while (elapsedTime < openDuration)
        {
            door.position = Vector3.Lerp(doorOriginalPosition, openPosition, elapsedTime / openDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        door.position = openPosition;

        yield return new WaitForSeconds(waitTime);

        elapsedTime = 0f;
        while (elapsedTime < openDuration)
        {
            door.position = Vector3.Lerp(openPosition, doorOriginalPosition, elapsedTime / openDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        door.position = doorOriginalPosition;
    }
}
