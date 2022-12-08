using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoxTurning : MonoBehaviour
{

    bool hover = false;

    private List<InputDevice> controlers;

    public InputActionProperty leftAxisMovement;
    public InputActionProperty rightAxisMovement;

    public void OnHover()
    {
        hover = true;
    }

    public void OnLeave()
    {
        hover = false;
    }

    private void Update()
    {
        if (hover)
        {
            Vector2 leftHand = leftAxisMovement.action.ReadValue<Vector2>();
            Vector2 rightHand = rightAxisMovement.action.ReadValue<Vector2>();

            transform.parent.rotation *= Quaternion.Euler(0, leftHand.x * 30 * Time.deltaTime, 0);
            transform.parent.rotation *= Quaternion.Euler(0, rightHand.x * 30 * Time.deltaTime, 0);
        }
    }
}
