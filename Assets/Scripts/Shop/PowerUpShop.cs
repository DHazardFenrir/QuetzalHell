using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUpShop : MonoBehaviour
{
    [SerializeField] Image powerUpImage = default;
    [SerializeField] TMP_Text powerUpnameLabel = default;
    [SerializeField] TMP_Text costLabel = default;
    [SerializeField] Button button = default;

    private PowerUp powerup;
    private Shop shop;

    public void Init(PowerUp powerup, Shop shop)
    {
        this.powerup = powerup;
        this.shop = shop;
        powerUpImage.sprite = powerup.powerUp.sprite;
        powerUpnameLabel.text = powerup.powerUp.name;
        costLabel.text = "Cost:  " + powerup.cost;
        button.onClick.AddListener(OptionClick);

    }

    private void OptionClick()
    {
        shop.TryBuyPowerUp(powerup);
    }

}
