using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinninPuzzle : MonoBehaviour
{
    public Transform parent;
    public Transform lookAtMe;
    public Transform spinningImage;
    public int spinningImageFinalAngle;
    

    private float myY;
    private float distance;

    public bool grabbed;



    private void Start()
    {
        distance = Vector2.Distance(lookAtMe.localPosition, parent.parent.transform.localPosition);
    }

    public void OnGrab()
    {
        grabbed = true;
    }

    public void GrabStopped()
    {
        grabbed = false;
        transform.position = parent.position;
    }

    private void Update()
    {
        if (grabbed)
        {
            
            lookAtMe.position = transform.position;
            lookAtMe.localPosition = new Vector3(lookAtMe.localPosition.x, 0, lookAtMe.localPosition.z);
            lookAtMe.localPosition = Vector3.ClampMagnitude(lookAtMe.localPosition, 0.14f);

            parent.parent.LookAt(lookAtMe);
            parent.parent.localRotation = Quaternion.Euler(parent.parent.localEulerAngles.x, parent.parent.localEulerAngles.y, 0);
            spinningImage.localRotation = parent.parent.localRotation;

            if (spinningImageFinalAngle - 5 < spinningImage.localEulerAngles.y && spinningImageFinalAngle + 5 > spinningImage.localEulerAngles.y)
                spinningImage.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            else
                spinningImage.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }
}
