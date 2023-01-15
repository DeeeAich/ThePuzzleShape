using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTurning : MonoBehaviour
{
    public Transform keyGameobject;
    // Update is called once per frame
    void FixedUpdate()
    {

        keyGameobject.localRotation = Quaternion.Euler(transform.localRotation.x*Mathf.Rad2Deg - 90, keyGameobject.localRotation.y, keyGameobject.localRotation.z);
    }

    public void ResetPos()
    {
        transform.position = keyGameobject.position;
    }
}
