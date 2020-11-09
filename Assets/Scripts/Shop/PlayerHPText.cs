using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHPText : MonoBehaviour
{
    [SerializeField] HealthPlayer player = default;
    [SerializeField] TMP_Text playerHpLabel = default;

    
    private void OnEnable()
    {
        player.onDamageTaken += onHealthChange;
    }
    private void OnDisable()
    {
        player.onDamageTaken -= onHealthChange;
    }
    private void onHealthChange(int currentHealth)
    {
        playerHpLabel.text = "HP: " + currentHealth.ToString();
    }
}
