using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contentserver : MonoBehaviour
{
    [Header("Windowtoopen")]
    public GameObject window;

    public void openWindow()
    {
        window.SetActive(true);
        window.transform.position = new Vector3(0, 0, 0);
    }
}
