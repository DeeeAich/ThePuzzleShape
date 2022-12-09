using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private Lever firstLever, secondLever;
    [SerializeField] private LeverManager leverManager;
    [SerializeField] private float firstLeverDir;
    [SerializeField] private float secondLeverDir;

    private Rigidbody rb;

    private float upRotation = 70;
    private float downRotation = -70;
    private float midRotation = 0;

    public float rotationSpeed = 5f;

    private Quaternion previous;

    bool isActiveLever = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        previous = transform.localRotation;
    }

    private void OnMouseDrag()
    {
        float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;

        transform.Rotate(Vector3.right, YaxisRotation);
    }

    private void Update()
    {
        if (isActiveLever)
        {
            if (firstLever != null)
            {
                firstLever.ADC(transform.localRotation.x * 126 - previous.x, firstLeverDir);
            }

            if (secondLever != null)
            {
                secondLever.ADC(transform.localRotation.x * 126 - previous.x, secondLeverDir);
            }
        }

        if (rb.IsSleeping() && isActiveLever)
        {
            if (firstLever != null)
                firstLever.SNAP();

            if (secondLever != null)
                secondLever.SNAP();

            SNAP();

            isActiveLever = false;
            Debug.Log("Poop");
        }

        previous = transform.localRotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isActiveLever = true;

        Debug.Log("Gaming");
    }

    public void SNAP()
    {
        rb.angularVelocity = Vector3.zero;
        Debug.Log(transform.localRotation.x * 126);

        if (transform.localRotation.x * 126 > 35)
        {
            transform.localRotation = Quaternion.Euler(upRotation, 0, 0);
            Debug.Log(upRotation);
            return;
        }
        else if (transform.localRotation.x * 126 < -35)
        {
            transform.localRotation = Quaternion.Euler(downRotation, 0, 0);
            Debug.Log(downRotation);
            return;
        }
        else if (transform.localRotation.x * 126 >= -35 && transform.localRotation.x * 126 <= 35)
        {
            transform.localRotation = Quaternion.Euler(midRotation, 0, 0);
            Debug.Log(midRotation);
            return;
        }
        else
        {
            Debug.Log("Snap didn't work", this);
            return;
        }
    }

    public void ADC(float change, float match)
    {
        Quaternion newRotation = Quaternion.Euler(change * match, 0, 0);
        transform.localRotation = newRotation;
    }
}
