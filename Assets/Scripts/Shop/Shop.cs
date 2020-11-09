using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] ShopStatus statusValue = default;
    [SerializeField] Image currentPowerUpImage = default;
    [SerializeField] GameObject powerUpPrefab = default;
 
    [SerializeField] Inventory inventory = default;
    [SerializeField] GameObject shopPowerUp = default;
    [SerializeField] Transform shopPowerUpParent = default;
    QuetzalPlayer player;
    PlayerData data;
 
    private void Start()
    {
        OpenPowerUpShop();
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
      
       
        

    }

    public void TryBuyPowerUp(PowerUp powerup)
    {
        if(inventory.CurrentFeatherPoints >= powerup.cost)
        {
            inventory.ReduceFeatherPoints(powerup.cost);
            PowerUp pu = data.activePowerUp;
            player.PowerUpStats(pu);
           
            

            
        }
    }
}
