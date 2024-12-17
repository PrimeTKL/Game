using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WordByWordEffect : MonoBehaviour
{
    public Text storyText;
    public string[] storyLines;
    public float wordDisplaySpeed = 0.5f;

    private int currentLineIndex = 0;

    void Start()
    {
        gameObject.SetActive(true);
        storyText.text = "";
        StartCoroutine(DisplayStory());
    }

    IEnumerator DisplayStory()
    {
        while (currentLineIndex < storyLines.Length)
        {
            string[] words = storyLines[currentLineIndex].Split(' ');
            storyText.text = "";

            foreach (string word in words)
            {
                storyText.text += word + " ";
                yield return new WaitForSeconds(wordDisplaySpeed);
            }

            currentLineIndex++;
            yield return new WaitForSeconds(1f);
        }
        gameObject.SetActive(false);
    }
}
