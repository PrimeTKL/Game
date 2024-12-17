using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    public FinishPoint finishPoint;
    public Timer timer;
    AudioManager audioManager;

    [SerializeField] GameObject victory;
    [SerializeField] Sprite blackStarSprite;
    [SerializeField] Sprite yellowStarSprite;
    [SerializeField] Image[] stars;

    [SerializeField] GameObject desgin;

    private void Start()
    {
        if (finishPoint == null)
        {
            finishPoint = FindObjectOfType<FinishPoint>();
        }

        if (timer == null)
        {
            timer = FindObjectOfType<Timer>();
        }
        if (audioManager == null)
        {
            audioManager = FindObjectOfType<AudioManager>();
        }
    }

    private void Update()
    {
        if (finishPoint.checkFinishPoint == true)
        {
            finishPoint.checkFinishPoint = false;
            desgin.SetActive(false);
            YouWin();
        }
    }

    public void YouWin()
    {
        if (audioManager != null && audioManager.gameOver != null)
        {
            audioManager.PlaySFX(audioManager.victory);
        }
        if (victory != null)
        {
            victory.SetActive(true);
            victory.transform.localScale = Vector3.zero;

            Sequence sequence = DOTween.Sequence();
            sequence.Append(victory.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack));

            Transform secondChild = victory.transform.childCount > 1 ? victory.transform.GetChild(1) : null;

            if (secondChild != null)
            {
                stars = new Image[secondChild.childCount];
                for (int i = 0; i < secondChild.childCount; i++)
                {
                    stars[i] = secondChild.GetChild(i).GetComponent<Image>();
                    stars[i].sprite = blackStarSprite;
                }

                int starCount = CalculateStars(timer.remainingTime, timer.initialTime);

                for (int i = 0; i < starCount; i++)
                {
                    int index = i;
                    sequence.AppendCallback(() =>
                    {
                        stars[index].sprite = yellowStarSprite;
                        stars[index].transform.localScale = Vector3.zero;
                        stars[index].transform.DOScale(1.2f, 0.5f).SetEase(Ease.OutBack).OnComplete(() =>
                        {
                            stars[index].transform.DOScale(1f, 0.3f);
                        });
                    });
                    sequence.AppendInterval(0.5f);
                }
            }

            sequence.OnComplete(() => Time.timeScale = 0);
        }
    }

    private int CalculateStars(float remainingTime, float initialTime)
    {
        float oneThirdTime = initialTime / 3;

        if (remainingTime > 2 * oneThirdTime) return 3;
        else if (remainingTime > oneThirdTime) return 2;
        else return 1;
    }

    public void Home()
    {
        desgin.SetActive(true);
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1;
    }
    public void Replay()
    {
        desgin.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void NextLevel()
    {
        desgin.SetActive(true);
        SceneController.instance.NextLevel();
        Time.timeScale = 1;
    }
}
