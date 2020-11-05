using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   public int CurrentFeatherPoints { get; private set; }
    public event Action<int> onFeatherPointsChanged;

    private void Start()
    {
        onFeatherPointsChanged?.Invoke(0);
    }

    public void AddFeatherPoints(int amount)
    {
        CurrentFeatherPoints += amount;
        onFeatherPointsChanged?.Invoke(CurrentFeatherPoints);
    }

    public void ReduceFeatherPoints(int amount)
    {
        CurrentFeatherPoints -= amount;
        onFeatherPointsChanged?.Invoke(CurrentFeatherPoints);
    }
    [ContextMenu("Add 100 FeatherPoints")]
    public void Test_AddFeathers()
    {
        AddFeatherPoints(100);
    }
}
