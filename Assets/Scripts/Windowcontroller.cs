using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windowcontroller : MonoBehaviour
{
    public Animator anim;
    public Buddycontroller buddy;
    public GameObject closebutton;

    public void Awake()
    {
        anim.Play("windowopen");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.layer == 6)
        {
            if (collision.gameObject.layer == 3)
            {
                anim.SetBool("bigger", true);
            }
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (this.gameObject.layer == 6)
        {
            if (collision.gameObject.layer == 3)
            {
                anim.SetBool("bigger", true);
                buddy.currentwindow = this;
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (this.gameObject.layer == 6)
        {
            if (collision.gameObject.layer == 3)
            {
                anim.SetBool("bigger", false);
            }
        }
    }

    public void close()
    {
        anim.SetBool("close", true);
    }
    public void closeWindow()
    {
        this.gameObject.SetActive(false);
        anim.SetBool("bigger", false);
        anim.SetBool("close", false);
    }
}
