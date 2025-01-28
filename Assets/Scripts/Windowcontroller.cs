using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Windowcontroller : MonoBehaviour
{
    public Animator anim;
    public Buddycontroller buddy;
    public GameObject closebutton;
    public GameObject text;
    public TMP_Text pulltext;
    public int currentposition;
    public Canvas can;
    public BoxCollider2D centcol;

    public void Awake()
    {
        anim.Play("windowopen");
        pushtofront();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.layer == 6 && currentposition == 1)
        {
            if (collision.gameObject.layer == 3)
            {
                pushtofront();
                currentposition = 1;
                can.sortingOrder = 10;
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
                centcol.enabled = true;
                currentposition = 1;
                can.sortingOrder = 10;
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

    public void textrip()
    {
        if (pulltext.text != "")
        {
            buddy.heldstring = pulltext.text;
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


    public void pushtofront()
    {
        Debug.Log("push");
        buddy.windows.RemoveAt(buddy.windows.IndexOf(this));
        foreach (Windowcontroller d in buddy.windows)
        {
            d.centcol.enabled = false;
            d.currentposition++;
            d.anim.SetBool("bigger", false);
            d.can.sortingOrder--;
        }
        buddy.windows.Insert(0, this);
        Debug.Log("set");
        centcol.enabled = true;
    }
}
