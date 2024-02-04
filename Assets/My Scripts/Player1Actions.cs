using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Actions : MonoBehaviour
{
    public float JumpSpeed = 1f;
    public GameObject Player1;
    private Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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
        if (Input.GetButton("Jump"))
        {
            Anim.SetTrigger("HeavyPunch");
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
