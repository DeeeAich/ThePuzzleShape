using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTurning : MonoBehaviour
{
    public Transform keyGameobject;
    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion.RotateTowards(keyGameobject.rotation, Quaternion.Euler( transform.rotation.x * Mathf.Rad2Deg - 90, 0, 0), Time.deltaTime * 10);
        Debug.Log(transform.localRotation.x * 126);
    }

    public void ResetPos()
    {
        transform.position = keyGameobject.position;
    }
}
