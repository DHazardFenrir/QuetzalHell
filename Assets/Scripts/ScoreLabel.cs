using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreLabel : MonoBehaviour
{
    [SerializeField] Inventory inventory = default;
    [SerializeField] TMP_Text scoreLabel = default;

    private void OnEnable()
    {
        inventory.onFeatherPointsChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        inventory.onFeatherPointsChanged -= OnScoreChanged;
    }
    private void OnScoreChanged(int currenValue)
    {
        scoreLabel.text = currenValue.ToString();
    }
}
