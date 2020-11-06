using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] ShopStatus statusValue = default;
    [SerializeField] Image currentPowerUpImage = default;
    [SerializeField] Transform powerUpCraftedParent = default;
    [SerializeField] GameObject powerUpCraftedPrefab = default;
    [SerializeField] Inventory inventory = default;
    [SerializeField] GameObject shopPowerUp = default;
    [SerializeField] GameObject craftWindow = default;

    private void Start()
    {
        
    }

    public void OpenShop()
    {
        craftWindow.SetActive(true);
        shopPowerUp.SetActive(false);

    }

    public void Clean()
    {
        DestroyAllChildren(powerUpCraftedParent);
        OpenPowerUpShop();
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
        craftWindow.SetActive(false);
        DestroyAllChildren(powerUpCraftedParent);

    }

    public void TryBuyPowerUp()
    {

    }
}
