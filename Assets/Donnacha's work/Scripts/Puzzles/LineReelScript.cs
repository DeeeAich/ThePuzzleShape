using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LineReelScript : MonoBehaviour
{
    LineConnection lineControl;
    bool held;
    bool finalPoint;
    public float minimumSpeed = 5;
    public float minimumDistance = 1;

    Transform lastPos;

    private void Start()
    {
        lineControl = transform.parent.GetComponent<LineConnection>();
    }
    public void Release()
    {
        
        held = false;
        if (!finalPoint)
        {
            lineControl.Clear();
        }
        else
            transform.SetParent(lastPos);
        transform.position = transform.parent.position;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Gear")
            lineControl.AddLinePoint(other.gameObject);

        if (other.gameObject.name == "EndPoint" && lineControl.gears.Count == 3)
            SetNewEndPoint(other.gameObject);


    }

    private void Update()
    {
        if (!held)
            GetComponent<Rigidbody>().velocity = new Vector3();

        if (finalPoint)
        {

            lineControl.lineControl.SetPosition(lineControl.lineControl.positionCount - 2, lastPos.position);

            float distance = Vector3.Distance(transform.position, lastPos.position);
            
            if (distance > minimumDistance)
            {
                GetComponent<XRGrabInteractable>().enabled = false;
                Release();
                //finished
            }
        }
    }

    private void SetNewEndPoint(GameObject endPoint)
    {
        if (finalPoint)
            return;

        finalPoint = true;
        lastPos = endPoint.transform; 
        lineControl.lineControl.SetPosition(lineControl.lineControl.positionCount - 1, endPoint.transform.position);
        lineControl.lineControl.positionCount++;

    }
}
