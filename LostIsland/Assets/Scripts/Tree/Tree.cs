using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tree : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            Debug.Log("BAM");
        }
    }
}
