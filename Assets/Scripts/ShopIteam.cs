using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShopItem : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text speedText;
    public TMP_Text attackText;

    private const string HealthKey = "ItemHealth";
    private const string SpeedKey = "ItemSpeed";
    private const string AttackKey = "ItemAttack";

    public Button healthButton;
    public Button speedButton;
    public Button attackButton;

    public int priceHealth ;
    public int priceSpeed ;
    public int priceAttack ;

    private void Start()
    {
        if (!PlayerPrefs.HasKey(HealthKey)) PlayerPrefs.SetInt(HealthKey, 0);
        if (!PlayerPrefs.HasKey(SpeedKey)) PlayerPrefs.SetInt(SpeedKey, 0);
        if (!PlayerPrefs.HasKey(AttackKey)) PlayerPrefs.SetInt(AttackKey, 0);

       
        UpdateUI();
    }

    public void BuyHealth()
    {
        int coins = PlayerPrefs.GetInt("PlayerCoinTong", 0);
        if (coins >= priceHealth)
        {
            PlayerPrefs.SetInt("PlayerCoinTong", coins - priceHealth);
            int currentHealth = PlayerPrefs.GetInt(HealthKey);
            PlayerPrefs.SetInt(HealthKey, currentHealth + 1);
            UpdateUI();
        }
    }

    public void BuySpeed()
    {
        int coins = PlayerPrefs.GetInt("PlayerCoinTong", 0);
        if (coins >= priceSpeed)
        {
            PlayerPrefs.SetInt("PlayerCoinTong", coins - priceSpeed);
            int currentSpeed = PlayerPrefs.GetInt(SpeedKey);
            PlayerPrefs.SetInt(SpeedKey, currentSpeed + 1);
            UpdateUI();
        }
    }

    public void BuyAttack()
    {
        int coins = PlayerPrefs.GetInt("PlayerCoinTong", 0);
        if (coins >= priceAttack)
        {
            PlayerPrefs.SetInt("PlayerCoinTong", coins - priceAttack);
            int currentAttack = PlayerPrefs.GetInt(AttackKey);
            PlayerPrefs.SetInt(AttackKey, currentAttack + 1);
            UpdateUI();
        }
    }

    private void UpdateUI()
    {

        
        healthText.text = "" + PlayerPrefs.GetInt(HealthKey);
        speedText.text = "" + PlayerPrefs.GetInt(SpeedKey);
        attackText.text = "" + PlayerPrefs.GetInt(AttackKey);


        int coins = PlayerPrefs.GetInt("PlayerCoinTong", 0);

        healthButton.interactable = coins >= priceHealth;
        speedButton.interactable = coins >= priceSpeed;
        attackButton.interactable = coins >= priceAttack;
    }

    public void ResetItems()
    {
       
        PlayerPrefs.SetInt(HealthKey, 0);
        PlayerPrefs.SetInt(SpeedKey, 0);
        PlayerPrefs.SetInt(AttackKey, 0);
        UpdateUI();
    }
}
