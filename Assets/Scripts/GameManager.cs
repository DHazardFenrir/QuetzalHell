using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject leftBoundary;                   //
    public GameObject rightBoundary;                  // References to the screen bounds: Used to ensure the player
    public GameObject topBoundary;                    // is not able to leave the screen.
    public GameObject bottomBoundary;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }
}
