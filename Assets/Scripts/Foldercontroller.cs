using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foldercontroller : MonoBehaviour
{
    public Transform spot;
    void Update()
    {
        transform.position = spot.position;
    }
}
