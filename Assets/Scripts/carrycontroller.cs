using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class carrycontroller : MonoBehaviour
{
    public GameObject buddy;
    public Buddycontroller buddycon;
    public TMP_Text text;

    public void Update()
    {
        transform.position = Vector3.Lerp(transform.position, buddy.transform.position, 0.001f);
        text.text = buddycon.heldstring;
    }
}
