using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    public Transform door;
    public float openDistance = 3f;
    public float openDuration = 1f;
    public float waitTime = 2f;

    public Sprite newSprite;
    private SpriteRenderer spriteRenderer;
    private bool isActivated = false; 

    private Vector3 doorOriginalPosition;

    void Start()
    {
        if (door != null)
        {
            doorOriginalPosition = door.position;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && door != null && !isActivated)
        {
            isActivated = true; 
            StartCoroutine(OpenAndCloseDoor());
            ChangeSprite();
        }
    }

    private IEnumerator OpenAndCloseDoor()
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

        //dong cua
        //yield return new WaitForSeconds(waitTime);

       
        //elapsedTime = 0f;
        //while (elapsedTime < openDuration)
        //{
        //    door.position = Vector3.Lerp(openPosition, doorOriginalPosition, elapsedTime / openDuration);
        //    elapsedTime += Time.deltaTime;
        //    yield return null;
        //}
        //door.position = doorOriginalPosition;
        ////
    }

    private void ChangeSprite()
    {
        if (spriteRenderer != null && newSprite != null)
        {
            spriteRenderer.sprite = newSprite;
        }
    }
}
