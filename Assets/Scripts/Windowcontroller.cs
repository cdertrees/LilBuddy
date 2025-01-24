using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windowcontroller : MonoBehaviour
{
    public Animator anim;

    public void Awake()
    {
        anim.Play("windowopen");
    }
}
