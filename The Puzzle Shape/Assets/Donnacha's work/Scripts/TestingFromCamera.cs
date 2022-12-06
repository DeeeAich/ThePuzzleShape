using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingFromCamera : MonoBehaviour
{
    Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit))
            {
                Debug.Log(hit);
                if (hit.transform.name == "Start Button")
                    hit.transform.GetComponent<SimonSays>().StartSimon();
                if (hit.transform.name == "Colour Button")
                    if(hit.transform.GetComponent<SimonButton>().pressable)
                        hit.transform.GetComponent<SimonButton>().PressedByPlayer();
            }

        }

    }
}
