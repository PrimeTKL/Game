using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointEndgame : MonoBehaviour
{
    public GameObject hoiThoai;

    private WordByWordEffect hoithoaiEffect;

    public Timer timer;
    void Start()
    {
        if (timer == null)
        {
            timer = FindObjectOfType<Timer>();
        }

        if (hoiThoai != null)
        {
            hoithoaiEffect = hoiThoai.GetComponent<WordByWordEffect>();
            hoiThoai.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (timer != null)
            {
                timer.PauseTimer();
            }

            StartCoroutine(StartSequence());
        }
    }

    private IEnumerator StartSequence()
    {

        if (hoiThoai != null && hoithoaiEffect != null)
        {
            hoiThoai.SetActive(true);
            yield return StartCoroutine(hoithoaiEffect.DisplayStory());
            yield return new WaitForSecondsRealtime(1f);
        }

        if (timer != null)
        {
            timer.ResumeTimer();
        }
    }

}
