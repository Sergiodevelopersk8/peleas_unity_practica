using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Actions : MonoBehaviour
{
    public float JumpSpeed = 1f;
    public GameObject Player1;
    private Animator Anim;
    private AnimatorStateInfo Player1Layer0;
    public float PunchMoveAmt = 0.2f;
    private bool HeavyMoving = false;
    public float PunchSlideAmt = 2f;
    private AudioSource MyPlayer;
    public AudioClip PunchWoosh;
    public AudioClip KickWoosh;
    public static bool Hits = false;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        MyPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(HeavyMoving == true)
        {
            if (Player2Move.FacingRightP2 == true)
            {
             Player1.transform.Translate(PunchSlideAmt * Time.deltaTime, 0, 0);

            }

            if(Player2Move.FacingLeftP2 == true)
            {
                Player1.transform.Translate(-PunchSlideAmt * Time.deltaTime, 0, 0);

            }



        }
        Player1Layer0 = Anim.GetCurrentAnimatorStateInfo(0);


        //STADING ATTACK

        if (Player1Layer0.IsTag("Motion"))
        {


        if (Input.GetButtonDown("Fire1P2"))
        {

                /*fire 1 -> c*/
                Anim.SetTrigger("LightPunch");
        }
        if (Input.GetButtonDown("Fire2P2"))
        {
                /*fire 2 -> v*/
                Anim.SetTrigger("HeavyPunch");
        }
        if (Input.GetButtonDown("Fire3P2"))
        {
                /*fire 3 -> b*/
                Anim.SetTrigger("LightKick");
        }
        if (Input.GetButtonDown("Fire4P2"))
        {
                /*fire 4 -> n*/
                Anim.SetTrigger("HeavyKick");
        }

            if (Input.GetButtonDown("Fire5P2"))
            {
                /*fire 5 -> m*/
                Anim.SetTrigger("HeavyKick");
            }

            if (Input.GetButtonDown("Block"))
            {
                Anim.SetTrigger("BlockOn");
            }

          


        }

        if (Player1Layer0.IsTag("Block"))
        {
            if (Input.GetButtonUp("Block"))
            {
                Anim.SetTrigger("BlockOff");
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

    public void PunchWooshSound()
    {
        MyPlayer.clip = PunchWoosh;
        MyPlayer.Play();
    }
    


    public void KickWooshSound()
    {
        MyPlayer.clip = KickWoosh;
        MyPlayer.Play();
    }



    IEnumerator PunchSlide()
    {
        HeavyMoving = true;
        yield return new WaitForSeconds(0.1f);
        HeavyMoving = false;
    }


}
