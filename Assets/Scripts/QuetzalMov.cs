using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class QuetzalMov : MonoBehaviour
{
    private Transform playerQuetzal;
    private Rigidbody m_Rb;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
   
    [SerializeField] float speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_Rb = GetComponent<Rigidbody>();
        playerQuetzal = this.transform;
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
            int dir = Input.GetKeyDown(KeyCode.Space) ? -1 : 1;
            QuickSpin(dir);
        }
      
        HorizontalLean(playerQuetzal, v, 5, 1f);
        VerticalLean(playerQuetzal, h, 20, 1f);
    }

   

    void QuickSpin(int dir)
    {
        playerQuetzal.DOLocalRotate(new Vector3(playerQuetzal.localEulerAngles.x, playerQuetzal.localEulerAngles.y, 360 * -dir), .4f, RotateMode.LocalAxisAdd).SetEase(Ease.OutSine);

    }

    void HorizontalLean(Transform target, float axis, float leanLimit, float lerpTime )
    {
        Vector3 targetEulerAngles = target.localEulerAngles;
        target.localEulerAngles = new Vector3(targetEulerAngles.x, targetEulerAngles.y, Mathf.LerpAngle(targetEulerAngles.z, -axis * leanLimit, lerpTime)); //Learps Horizontally creating the effect of semi-rotation when you move, like a bird.

    }

    void VerticalLean(Transform target, float axis, float leanLimit, float lerpTime)
    {
        Vector3 targetEulerAngles = target.localEulerAngles;
        target.localEulerAngles = new Vector3(targetEulerAngles.z, targetEulerAngles.y, Mathf.LerpAngle(targetEulerAngles.z, axis * leanLimit, lerpTime));//Learps Vertically creating the effect of semi-rotation when you move, like a bird. To break and accelerate. 
    }
     //Lean = Inclinacion. 
    
}
