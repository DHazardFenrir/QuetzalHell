using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements.Experimental;

public class QuetzalMov : MonoBehaviour
{
    private Transform playerQuetzal;
    private Rigidbody m_Rb;
    private Vector3 moveInput;
    Quaternion rotation;
    Color[] colors = { Color.blue, Color.yellow, Color.red };
    int i = 0;


    [SerializeField]bool isBarrelRoll;
   
    [SerializeField] float speed = 0;
    [SerializeField] GameObject myShield;
    // Start is called before the first frame update
    void Start()
    {
        m_Rb = GetComponent<Rigidbody>();
        playerQuetzal = this.transform;
        rotation = transform.localRotation;
        rotation.y = 1f;
       if(myShield != null)
        {
            Debug.Log("I have Shield");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        moveInput = new Vector3(h, 0, v);
        m_Rb.velocity = moveInput * speed;



        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //int dir = Input.GetKeyDown(KeyCode.Space) ? -1 : 1;
                //QuickSpin(dir);

                // HAK: Use the Horizontal axis to get the proper direction
                QuickSpin(h > 0 ? 1 : -1);
            }
           



        }
        StopCoroutine(BarrelRoll());

        HorizontalLean(playerQuetzal, v, 5, 1f);


        // HAK: Avoid the gimbal lock
        if (v >= 0)
        {
            VerticalLean(playerQuetzal, h, 20, 1f);
        }
    }

   

    void QuickSpin(int dir)
    {
        if (isBarrelRoll)
            return;
        isBarrelRoll = true;
       
        playerQuetzal.DOLocalRotate(new Vector3(playerQuetzal.localEulerAngles.x, playerQuetzal.rotation.y, 359* -dir), .4f, RotateMode.LocalAxisAdd).SetEase(Ease.OutSine);
        StartCoroutine(BarrelRoll());
        i++;
        ChangeShield(i);

        if(i == colors.Length)
        {
            i = 0;
        }
    }

    void HorizontalLean(Transform target, float axis, float leanLimit, float lerpTime )
    {
        Vector3 targetEulerAngles = target.localEulerAngles;
        target.localEulerAngles = new Vector3(targetEulerAngles.x, targetEulerAngles.y, Mathf.LerpAngle(targetEulerAngles.z, axis * leanLimit, lerpTime)); //Learps Horizontally creating the effect of semi-rotation when you move, like a bird.

    }

    void VerticalLean(Transform target, float axis, float leanLimit, float lerpTime)
    {
        Vector3 targetEulerAngles = target.localEulerAngles;
        target.localEulerAngles = new Vector3(targetEulerAngles.z, targetEulerAngles.y, Mathf.LerpAngle(targetEulerAngles.z, -axis * leanLimit, lerpTime));//Learps Vertically creating the effect of semi-rotation when you move, like a bird. To break and accelerate. 
    }
     //Lean = Inclinacion. 
    
    IEnumerator BarrelRoll()
    {
       
        yield return new WaitForSeconds(0.45f);
        isBarrelRoll = false;
        rotation.y = 0f;
        
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }
    }

    void ChangeShield(int j)
    {
        var myShieldRendered = myShield.GetComponent<Renderer>();

        if(j == 1)
        {
            myShieldRendered.material.SetColor("_Emission", colors[0]);
        }

        if (j == 2)
        {
            myShieldRendered.material.SetColor("_Emission", colors[1]);
        }

        if (j == 3)
        {
            myShieldRendered.material.SetColor("_Emission", colors[2]);
        }


    }
}
