using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShield : MonoBehaviour
{
    [SerializeField] GameObject myShield;
    [SerializeField]PlayerData data = default;
    private int currentType;
    Color[] colors = { Color.red, Color.blue, Color.yellow};

    
    // Start is called before the first frame update
    public void ChangeShield(int numb)
    {
        var myShieldRendered = myShield.GetComponent<Renderer>();

        if (numb == 1)
        {
            myShieldRendered.material.SetColor("_Emission", colors[0]);
            
            
        }

        if (numb == 2)
        {
            myShieldRendered.material.SetColor("_Emission", colors[1]);
        

        }

        if (numb == 3)
        {
            myShieldRendered.material.SetColor("_Emission", colors[2]);
           

        }

        currentType = numb - 1;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            Bullet bullet = other.GetComponent<Bullet>();


            NoDamageShield(bullet.Type);

        }
    }

    public void NoDamageShield(BulletType type)
    {
       

        if (data.baseStats.bulletType[currentType].Equals(type))
        {
            Debug.Log("No Damage");
        }
        else
        {
            Debug.Log("Damage");
        }
    }


}
