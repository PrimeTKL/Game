using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class ConversationCheckpoint : MonoBehaviour
{
    public GameObject portalEnd;
    public GameObject matquai;
    public GameObject portal;
    public GameObject congChua;
    public GameObject hoithoai2; 
    public GameObject hoithoai3; 
    public GameObject hoithoai4;
    public Timer timer;

    private WordByWordEffect hoithoai2Effect;
    private WordByWordEffect hoithoai3Effect;
    private WordByWordEffect hoithoai4Effect;

    void Start()
    {
        if (timer == null)
        {
            timer = FindObjectOfType<Timer>();
        }

        
        if (hoithoai2 != null)
        {
            hoithoai2Effect = hoithoai2.GetComponent<WordByWordEffect>();
            hoithoai2.SetActive(false); 
        }

        if (hoithoai3 != null)
        {
            hoithoai3Effect = hoithoai3.GetComponent<WordByWordEffect>();
            hoithoai3.SetActive(false); 
        }
        if (hoithoai4 != null)
        {
            hoithoai4Effect = hoithoai4.GetComponent<WordByWordEffect>();
            hoithoai4.SetActive(false);
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

        if (hoithoai2 != null && hoithoai2Effect != null)
        {
            hoithoai2.SetActive(true);
            yield return StartCoroutine(hoithoai2Effect.DisplayStory());
            yield return new WaitForSecondsRealtime(1f);
        }

        if (portalEnd != null)
        {
            portalEnd.SetActive(true);
            yield return new WaitForSecondsRealtime(2f);
        }

       
        if (matquai != null)
        {
            matquai.SetActive(true);
            yield return new WaitForSecondsRealtime(2f);
        }

        if (hoithoai3 != null && hoithoai3Effect != null)
        {
            hoithoai3.SetActive(true);
            yield return StartCoroutine(hoithoai3Effect.DisplayStory());
            yield return new WaitForSecondsRealtime(1f);
        }
        if (portal != null)
        {
            portal.SetActive(true);
            Collider2D portalCollider = portal.GetComponent<Collider2D>();
            yield return new WaitForSecondsRealtime(2f);
        }
        if (congChua != null)
        {
            SpriteRenderer congChuaRenderer = congChua.GetComponent<SpriteRenderer>();

            if (congChuaRenderer != null)
            {
               
                congChua.transform.DORotate(new Vector3(0, 0, 360), 2f, RotateMode.FastBeyond360)
                    .SetEase(Ease.OutQuad);

                
                congChuaRenderer.DOFade(0, 1f).SetEase(Ease.OutQuad);

                
            }

            yield return new WaitForSecondsRealtime(1f);
            congChua.SetActive(false);
        }
        if (hoithoai4 != null && hoithoai4Effect != null)
        {
            hoithoai4.SetActive(true);
            yield return StartCoroutine(hoithoai4Effect.DisplayStory());
            yield return new WaitForSecondsRealtime(2f);
        }
        if (matquai != null)
        {
            matquai.SetActive(false);
            yield return new WaitForSecondsRealtime(2f);
        }

        if (timer != null)
        {
            timer.ResumeTimer();
        }
        
    }
}
