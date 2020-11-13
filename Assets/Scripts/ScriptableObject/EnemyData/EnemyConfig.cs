using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Enemy Config", menuName ="Enemies/Config", order =0)]
public class EnemyConfig : ScriptableObject
{
    public float moveSpeed;
    public GameObject prefab;
    public bool isShooter;
    public float shootCandance;
    public float shootInitialWaitTime;
}
