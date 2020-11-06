using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShield : MonoBehaviour
{
    [SerializeField] GameObject myShield;
    PlayerData data = default;
    Color[] colors = { Color.blue, Color.yellow, Color.red };

  
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
        for(int i=0; i < data.baseStats.bulletType.Length; i++)
        {
            if (data.baseStats.bulletType[i].Equals(type) && data.baseStats.type[i])
            {
                Debug.Log("No Damage");
            }
            else
            {
                Debug.Log("Damage");
            }
        }
    }


}
