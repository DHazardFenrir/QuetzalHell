using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManger : MonoBehaviour
{
    public static PoolingManger instance;

    private void Awake()
    {
        instance = this;
    }

    public void useObject(GameObject obj, Vector3 pos, Quaternion rot)
    {
        Instantiate(obj, pos, rot);
    }
}
