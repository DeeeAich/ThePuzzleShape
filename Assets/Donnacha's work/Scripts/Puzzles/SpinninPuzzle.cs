using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SpinninPuzzle : MonoBehaviour
{
    public Transform parent;
    public Transform lookAtMe;
    public Transform spinningImage;
    public int spinningImageFinalAngle;
    

    private float myY;
    private float distance;

    public bool grabbed;
    bool completed = false;

    public GameObject arrowDirection;
    public List<Material> arrowColours = new List<Material>();


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
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        if (spinningImageFinalAngle - 9 < spinningImage.localEulerAngles.y && spinningImageFinalAngle + 9 > spinningImage.localEulerAngles.y)
        {
            completed = true;
            gameObject.SetActive(false);
            GetComponent<XRGrabInteractable>().enabled = false;
            PuzzleManager.PuzzleControl().puzzleCompleted++;
            
        }
    }

    private void Update()
    {

        if (grabbed && !completed)
        {
            Vector3 mirrorThis = transform.position;
            lookAtMe.position = mirrorThis;
            lookAtMe.localPosition = new Vector3(lookAtMe.localPosition.x, 0, lookAtMe.localPosition.z);
            lookAtMe.localPosition = Vector3.ClampMagnitude(lookAtMe.localPosition, 0.14f);

            parent.parent.LookAt(lookAtMe);
            parent.parent.localRotation = Quaternion.Euler(parent.parent.localEulerAngles.x, parent.parent.localEulerAngles.y, 0);
            spinningImage.localRotation = parent.parent.localRotation;

        }
        if (spinningImageFinalAngle - 9 < spinningImage.localEulerAngles.y && spinningImageFinalAngle + 9 > spinningImage.localEulerAngles.y)
            arrowDirection.GetComponent<MeshRenderer>().material = arrowColours[1];
        else
            arrowDirection.GetComponent<MeshRenderer>().material = arrowColours[0];
    }
}
