using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearSpinning : MonoBehaviour
{
    public bool rotate = false;
    public float spinSpeed = 60;

    // Update is called once per frame
    void Update()
    {
        if (rotate)
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, transform.localRotation * Quaternion.Euler(60, 0, 0), Time.deltaTime * spinSpeed);
    }
}
