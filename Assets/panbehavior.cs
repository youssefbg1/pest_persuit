using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panbehavior : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetBool("attacking",true);
        }else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            anim.SetBool("attacking", false);
        }

    }
}
