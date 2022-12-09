using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverManager : MonoBehaviour
{
    public GameObject lever1, lever2, lever3, lever4;
    public GameObject _selection;

    private void Update()
    {
        if (lever1.GetComponent<Transform>().localRotation.x == 0 && 
            lever2.GetComponent<Transform>().localRotation.x == 0 && 
            lever3.GetComponent<Transform>().localRotation.x == 0 && 
            lever4.GetComponent<Transform>().localRotation.x == 0)
        {
            Debug.Log("Woop Ya did it");

            lever1.GetComponent<Lever>().enabled = false;
            lever2.GetComponent<Lever>().enabled = false;
            lever3.GetComponent<Lever>().enabled = false;
            lever4.GetComponent<Lever>().enabled = false;

            lever1.GetComponent<CapsuleCollider>().enabled = false;
            lever2.GetComponent<CapsuleCollider>().enabled = false;
            lever3.GetComponent<CapsuleCollider>().enabled = false;
            lever4.GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}
