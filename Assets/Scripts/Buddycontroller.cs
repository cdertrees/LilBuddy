using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class Buddycontroller : MonoBehaviour
{
    #region setup
    [Header("Components")]
    public Animator anim;
    public SpriteRenderer cover;
    [Header("Gameobjects")] 
    public GameObject hpivot;
    public GameObject hand1;
    public GameObject hand2;
    [Header("Bools")]
    public bool up;
    public bool down;
    public bool left;
    public bool right;
    public bool step = true;
    [Header("Floats")] public float raycastdistance;
    #endregion
    void Update()
    {
        #region keysdown
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
            hpivot.transform.localScale = new Vector3(1, 1, 1);
            cover.enabled = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            right = true;
            transform.localScale = new Vector3(3, -3, 1);
            hpivot.transform.localScale = new Vector3(-1, 1, 1);
            cover.enabled = false;
        }
        #endregion
        #region keysup
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
        #endregion
    }

    public void FixedUpdate()
    {
        #region movement
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
        #endregion

        #region hands
        LayerMask mask = LayerMask.GetMask("window");
        
        RaycastHit2D uhit = Physics2D.Raycast(transform.position, Vector2.up,raycastdistance, mask);
        if (uhit)
        {
            UnityEngine.Debug.Log("uphit");
            hpivot.transform.rotation = Quaternion.Euler(0,0,270);
            anim.SetBool("Pushing", true);
            hand1.SetActive(true);
            hand2.SetActive(true);
        }
        RaycastHit2D dhit = Physics2D.Raycast(transform.position, Vector2.down,raycastdistance, mask);
        if (dhit)
        {
            UnityEngine.Debug.Log("downhit");
            hpivot.transform.rotation = Quaternion.Euler(0,0,90);
            anim.SetBool("Pushing", true);
            hand1.SetActive(true);
            hand2.SetActive(true);
        }
        RaycastHit2D lhit = Physics2D.Raycast(transform.position, Vector2.left,raycastdistance, mask);
        if (lhit)
        {
            UnityEngine.Debug.Log("lefthit");
            hpivot.transform.rotation = Quaternion.Euler(0,0,0);
            anim.SetBool("Pushing", true);
            hand1.SetActive(true);
            hand2.SetActive(true);
        }
        RaycastHit2D rhit = Physics2D.Raycast(transform.position, Vector2.right,raycastdistance, mask);
        if (rhit)
        {
            UnityEngine.Debug.Log("righthit");
            hpivot.transform.rotation = Quaternion.Euler(0,0,180);
            anim.SetBool("Pushing", true);
            hand1.SetActive(true);
            hand2.SetActive(true);
        }
        
        RaycastHit2D ahit1 = Physics2D.Raycast(transform.position, Vector2.down,raycastdistance, mask);
        RaycastHit2D ahit2 = Physics2D.Raycast(transform.position, Vector2.up,raycastdistance, mask);
        RaycastHit2D ahit3 = Physics2D.Raycast(transform.position, Vector2.left,raycastdistance, mask);
        RaycastHit2D ahit4 = Physics2D.Raycast(transform.position, Vector2.right,raycastdistance, mask);
        if (!ahit1&&!ahit2&&!ahit3&&!ahit4)
        {
            anim.SetBool("Pushing", false);
            hand1.SetActive(false);
            hand2.SetActive(false);
        }
        #endregion
    }
    public IEnumerator cd()
    {
        yield return new WaitForSeconds(0.3f);
        step = true;
    }
}
