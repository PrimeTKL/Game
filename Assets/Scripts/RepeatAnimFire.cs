using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatAnimFire : MonoBehaviour
{
    public Animator animator;
    public string Fire; 
    public float delayBetweenPlays = 2f; 

    private void Start()
    {
        StartCoroutine(PlayAnimationWithDelay());
    }

    IEnumerator PlayAnimationWithDelay()
    {
        while (true)
        {
            animator.Play(Fire);
            yield return new WaitForSeconds(delayBetweenPlays);

        }
    }
}
