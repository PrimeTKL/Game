using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public Transform destination;
    public float teleportDelay = 4f;
    GameObject player;
    //Animation anim;
    //Rigidbody2D playerRb;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //anim= player.GetComponent<Animation>();
        //playerRb = player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(Vector2.Distance(player.transform.position, transform.position) > 0.3f)
            {
                player.transform.position = destination.transform.position;
                //StartCoroutine(PortalIn());
            }
        }
    }
    private IEnumerator TeleportAfterDelay()
    {
        yield return new WaitForSeconds(teleportDelay); // Wait for the specified delay
        player.transform.position = destination.transform.position;
    }

    //IEnumerator PortalIn()
    //{
    //    playerRb.simulated=false;
    //    anim.Play("PortalIn");
    //    yield return new WaitForSeconds(0.5f);
    //    player.transform.position = destination.position;
    //    anim.Play("Portal Out");
    //    yield return new WaitForSeconds(0.5f);
    //    playerRb.simulated=true;
    //}
}
