using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Actions : MonoBehaviour
{
    public float JumpSpeed = 1f;
    public GameObject Player1;
    private Animator Anim;
    private AnimatorStateInfo Player1Layer0;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
            if (Input.GetButtonDown("Jump"))
            {
                Anim.SetTrigger("HeavyKick");
            }
        }



    }

    public void JumpUp()
    {
       Player1.transform.Translate(0, JumpSpeed, 0);
       
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




}
