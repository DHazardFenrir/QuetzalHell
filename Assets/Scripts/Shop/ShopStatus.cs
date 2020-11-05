using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Shop Status", menuName = "GameEvent/ShopStatus", order =1)]
public class ShopStatus : ScriptableObject
{
    public ShopStatusValue Status { get; private set; }
    private void Awake()
    {
        Status = ShopStatusValue.None;
    }

    public void SetStatus(ShopStatusValue status)
    {
        Status = status;
    }
}
public enum ShopStatusValue { None, Buying}
