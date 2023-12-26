using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Move : MonoBehaviour
{

    private Animator Anim;
    public float WalkSpeed = 0.1f;
    private bool IsJumping = false;
    private AnimatorStateInfo Player1Layer0;
    private bool CanWalkLeft = true;
    private bool CanWalkRight = true;
    
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Player1Layer0 = Anim.GetCurrentAnimatorStateInfo(0);
        Vector3 ScreenBound = Camera.main.WorldToScreenPoint(this.transform.position);

        if(ScreenBound.x > Screen.width - 200)
        {
            CanWalkRight = false;
        }

        if (ScreenBound.x < 200)
        {
            CanWalkLeft = false;
        }

        else if(ScreenBound.x > 200 && ScreenBound.x < Screen.width - 200)
        {
            CanWalkRight = true;
            CanWalkLeft = true;
        }



        if (Player1Layer0.IsTag("Motion")) { 
         if (Input.GetAxis("Horizontal") > 0){
          if(CanWalkRight == true){

            Anim.SetBool("Foward", true);
            
            transform.Translate(WalkSpeed, 0, 0);
          }
         }

        if (Input.GetAxis("Horizontal")  < 0)
        {
           if(CanWalkLeft == true)
                {
                    Anim.SetBool("Backward", true);
                    transform.Translate(-WalkSpeed, 0, 0);
                }
        }

         }


        if (Input.GetAxis("Horizontal") == 0)
        {
            Anim.SetBool("Foward", false);
            Anim.SetBool("Backward", false);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            /*if(IsJumping == false){ IsJumping = true;  Anim.SetTrigger("Jump"); StartCoroutine(JumpPause()); } */
            Anim.SetBool("Jumps", true);
           
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            Anim.SetBool("Crouch", true);
        }

        if (Input.GetAxis("Vertical") == 0)
        {
              Anim.SetBool("Crouch", false);
            Anim.SetBool("Jumps", false);
        }


    }

IEnumerator JumpPause()
    {
        yield return new WaitForSeconds(1.0f);
        IsJumping = false;
    }

}
