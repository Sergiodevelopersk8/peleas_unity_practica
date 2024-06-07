using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Actions : MonoBehaviour
{
    public float JumpSpeed = 1f;
    public GameObject Player1;
    private Animator Anim;
    private AnimatorStateInfo Player1Layer0;
    public float PunchMoveAmt = 0.2f;
    private bool HeavyMoving = false;
    public float PunchSlideAmt = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(HeavyMoving == true)
        {
            if (Player1Move.FacingRight == true)
            {
             Player1.transform.Translate(PunchSlideAmt * Time.deltaTime, 0, 0);

            }

            if(Player1Move.FacingLeft == true)
            {
                Player1.transform.Translate(-PunchSlideAmt * Time.deltaTime, 0, 0);

            }



        }
        Player1Layer0 = Anim.GetCurrentAnimatorStateInfo(0);


        //STADING ATTACK

        if (Player1Layer0.IsTag("Motion"))
        {


        if (Input.GetButton("Fire1"))
        {
            Anim.SetTrigger("LightPunch");
        }
        if (Input.GetButton("Fire2"))
        {
            Anim.SetTrigger("HeavyPunch");
        }
        if (Input.GetButton("Fire3"))
        {
            Anim.SetTrigger("LightKick");
        }
        if (Input.GetButton("Fire4"))
        {
            Anim.SetTrigger("HeavyKick");
        }

            if (Input.GetButton("Fire5"))
            {
                Anim.SetTrigger("HeavyKick");
            }


        }
        //
        if (Player1Layer0.IsTag("Crouching"))
        {
            if (Input.GetButtonDown("Fire3"))
            {
                Anim.SetTrigger("LightKick");
            }
        }

        //aerial attack



        if (Player1Layer0.IsTag("Jumping"))
        {
            if (Input.GetButton("Jump"))
            {
                Anim.SetTrigger("HeavyKick");
            }
        }



    }

    public void JumpUp()
    {
       Player1.transform.Translate(0, JumpSpeed, 0);
       
    }
    public void HeavyPunchMove()
    {
  
        Player1.transform.Translate(PunchMoveAmt * Time.deltaTime, 0, 0);
        

        // Player1.transform.Translate(0, 0, 0);
        
        
    }


    public void HeavyMove()
    {
        StartCoroutine(PunchSlide());
       
    }



    public void FlipUp()
    {
       Player1.transform.Translate(0, JumpSpeed, 0);
        Player1.transform.Translate(0.1f, 0,0);
    }

    public void FlipBack()
    {
       Player1.transform.Translate(0, JumpSpeed, 0);
        Player1.transform.Translate(-0.1f, 0,0);
    }

    IEnumerator PunchSlide()
    {
        HeavyMoving = true;
        yield return new WaitForSeconds(0.1f);
        HeavyMoving = false;
    }


}
