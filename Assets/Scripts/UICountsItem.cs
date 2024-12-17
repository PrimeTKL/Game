using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICountsItem : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text healthText;
    public TMP_Text speedText;
    public TMP_Text attackText;

    private const string HealthKey = "ItemHealth";
    private const string SpeedKey = "ItemSpeed";
    private const string AttackKey = "ItemAttack";
    void Start()
    {
        PlayerPrefs.SetInt(AttackKey, 3);
        PlayerPrefs.SetInt(SpeedKey, 3);
        PlayerPrefs.Save();
        CountsItem();
    }

    // Update is called once per frame
    void Update()
    {
        CountsItem();
    }
    public void CountsItem()
    {
        healthText.text = PlayerPrefs.GetInt(HealthKey).ToString();
        speedText.text = PlayerPrefs.GetInt(SpeedKey).ToString();
        attackText.text = PlayerPrefs.GetInt(AttackKey).ToString();
    }
}
