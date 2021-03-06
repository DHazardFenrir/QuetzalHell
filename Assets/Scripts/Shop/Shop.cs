﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
 
    [SerializeField] Image currentPowerUpImage = default;
    [SerializeField] GameObject powerUpPrefab = default;
    [SerializeField] GameObject areaShop= default;
    [SerializeField] Inventory inventory = default;
    [SerializeField] GameObject shopPowerUp = default;
    [SerializeField] Transform shopPowerUpParent = default;
    [SerializeField]QuetzalPlayer player;
    [SerializeField] GameObject playerArea = default;

    private void Start()
    {
        OpenPowerUpShop();
        areaShop.SetActive(true);
        playerArea.SetActive(true);
    }

  

    public void Clean()
    {
        DestroyAllChildren(shopPowerUpParent);
      
    }

    private void DestroyAllChildren(Transform parent)
    {
        for(int i=0; i< parent.childCount; i++)
        {
            Destroy(parent.GetChild(i).gameObject);
        }
    }

    private void OpenPowerUpShop()
    {
        shopPowerUp.SetActive(true);
        //DestroyAllChildren(shopPowerUpParent);
        var data = player.GetData();
        currentPowerUpImage.sprite = data.sprite;

        //for(int i=0; i< data.activePowerUp.Length; i++)
        //{
        //    GameObject optionObject = Instantiate(powerUpPrefab, shopPowerUpParent);
        //    PowerUpShop option = optionObject.GetComponent<PowerUpShop>();
        //    option.Init(data.activePowerUp[i], this);

        //}

        Time.timeScale = 0f;
        

    }

    public void TryBuyPowerUp(PowerUp powerup)
    {
        if(inventory.CurrentFeatherPoints >= powerup.cost)
        {
            inventory.ReduceFeatherPoints(powerup.cost);
            player.SetPowerUp(powerup);
           
           
            

            
        }
    }

    public void ExitShop()
    {
        shopPowerUp.SetActive(false);
        Clean();
        areaShop.SetActive(false);
        playerArea.SetActive(false);
        Time.timeScale = 1f;
        
    }
}
