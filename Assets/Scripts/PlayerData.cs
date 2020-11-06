using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Game/PlayerData", order =1)]
public class PlayerData : ScriptableObject
{
    //stats
    public PlayerBaseStats baseStats;
    public Sprite sprite;
    public GameObject prefab;
    public PowerUp activePowerUp;
}

[System.Serializable]
public struct PlayerBaseStats
{
    public int bulletDamage;
    public int attackSpeed;
    public float range;
    public BulletType[] bulletType;
   
    //ActivePowerUp;
}

[System.Serializable]
public struct PowerUp
{
    public int cost;
    public PlayerData powerUp;
}



