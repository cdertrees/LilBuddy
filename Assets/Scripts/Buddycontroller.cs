using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Buddycontroller : MonoBehaviour
{
    #region setup
    [Header("Components")]
    public Animator anim;
    public SpriteRenderer cover;
    [Header("Bools")]
    public bool up;
    public bool down;
    public bool left;
    public bool right;
    public bool step = true;
    #endregion
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            up = true;
            cover.enabled = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            down = true;
            cover.enabled = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            left = true;
            transform.localScale = new Vector3(-3, -3, 1);
            cover.enabled = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            right = true;
            transform.localScale = new Vector3(3, -3, 1);
            cover.enabled = false;
        }
        
        if (Input.GetKeyUp(KeyCode.W))
        {
            up = false;
            anim.SetBool("Walking", false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            down = false;
            anim.SetBool("Walking", false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            left = false;
            anim.SetBool("Walking", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            right = false;
            anim.SetBool("Walking", false);
        }
    }

    public void FixedUpdate()
    {
        if (up || down || left || right)
        {
            anim.SetBool("Walking", true);
        }

        if (up)
        {
            if (step)
            {
                step = false;
                transform.Translate(Vector3.up * 0.3f);
                StartCoroutine(cd());
            }
        }
        if (down)
        {
            if (step)
            {
                step = false;
                transform.Translate(Vector3.up * -0.3f);
                StartCoroutine(cd());
            }
        }
        if (left)
        {
            if (step)
            {
                step = false;
                transform.Translate(Vector3.left * 0.3f);
                StartCoroutine(cd());
            }
        }
        if (right)
        {
            if (step)
            {
                step = false;
                transform.Translate(Vector3.left * -0.3f);
                StartCoroutine(cd());
            }
        }
    }
    public IEnumerator cd()
    {
        yield return new WaitForSeconds(0.3f);
        step = true;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        anim.SetBool("Pushing", true);
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        anim.SetBool("Pushing", false);
    }
}
