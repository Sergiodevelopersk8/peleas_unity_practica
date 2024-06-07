using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Move : MonoBehaviour
{
private Animator Anim;
    public float WalkSpeed = 0.07f;
    private bool IsJumping = false;
    private AnimatorStateInfo Player1Layer0;
    private bool CanWalkLeft = true;
    private bool CanWalkRight = true;
    public GameObject Player1;
    public GameObject Oppenent;
    private Vector3 OppPosition;
    public static  bool FacingLeft = false;
    public static bool FacingRight = true;


    private void Start()
    {

        Anim = GetComponentInChildren<Animator>();
        StartCoroutine(FaceRight());


    }

    void Update()
    {
        //listen to the animator
        Player1Layer0 = Anim.GetCurrentAnimatorStateInfo(0);

        //cannot exit screen
        Vector3 ScreenBounds = Camera.main.WorldToScreenPoint(this.transform.position);

        if(ScreenBounds.x > Screen.width - 200)
        {
            CanWalkRight = false;
        }
        
        if(ScreenBounds.x < 200)
        {
            CanWalkLeft = false;
        }

        else if(ScreenBounds.x > 200 && ScreenBounds.x < Screen.width - 200)
        {
            CanWalkRight = true;
            CanWalkLeft = true;
        }


        //get the opponent position

        OppPosition = Oppenent.transform.position;

        //Face left o right of opponent

        if(OppPosition.x > Player1.transform.position.x)
        {
            StartCoroutine(FaceLeft());
        }

if(OppPosition.x < Player1.transform.position.x)
        {

            StartCoroutine(FaceRight());
        }


    
        //Caminando dercha y izquierda
        if (Player1Layer0.IsTag("Motion"))
        {

        
        if (Input.GetAxis("Horizontal") > 0)
        {
            if(CanWalkRight == true)
            {            
             Anim.SetBool("Forward", true);
             transform.Translate(WalkSpeed, 0, 0);
            }
        
            }

        if (Input.GetAxis("Horizontal") < 0)
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
            Anim.SetBool("Forward", false);
            Anim.SetBool("Backward", false);
        }
        //salto 
        if (Input.GetAxis("Vertical") > 0)
        {
            if (IsJumping == false)
            {
                IsJumping = true;
            Anim.SetBool("Jump", true);
                Anim.SetTrigger("Salto");
                StartCoroutine(JumpPause());

            }
            
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            Anim.SetBool("Crouch", true);
            
        }
        if (Input.GetAxis("Vertical") == 0)
        {  
            Anim.SetBool("Jump", false);
            Anim.SetBool("Crouch", false);
        }

    }


    IEnumerator JumpPause()
    {
        yield return new WaitForSeconds(0.15f);
        IsJumping = false;
    }

    IEnumerator FaceLeft()
    {
       if(FacingLeft == true)
        {
            FacingLeft = false;
            FacingRight = true;
            yield return new WaitForSeconds(0.15f);
            Player1.transform.Rotate(0, 180 , 0);
            Anim.SetLayerWeight(1, 0);
        }


    }

    IEnumerator FaceRight()
    {

        if (FacingRight == true)
        {
            FacingRight = false;
            FacingLeft = true;
            yield return new WaitForSeconds(0.15f);
            Player1.transform.Rotate(0, -180, 0);
            Anim.SetLayerWeight(1, 1);
        }




    }



}
