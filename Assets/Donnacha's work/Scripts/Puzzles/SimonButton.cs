using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SimonButton : MonoBehaviour
{
    public int i;
    public Material norm;
    public Material highlight;
    public bool pressable = false;

    public float timer = 0.2f;

    private SimonSays simonControl;

    private void Start()
    {
        simonControl = transform.parent.GetComponent<SimonSays>();
    }

    private void ChangeMatNorm()
    {
        GetComponent<MeshRenderer>().material = norm;
        if(simonControl.onHold)
            simonControl.NextSimon();
        else if(!simonControl.onHold)
            simonControl.CheckButton(this);
    }
    private void ChangeMatHigh()
    {
        GetComponent<MeshRenderer>().material = highlight;

        //audio cue here

        Invoke(nameof(ChangeMatNorm), timer);
    }

    public void PressedByParent()
    {
        ChangeMatHigh();
    }

    public void PressedByPlayer()
    {
        ChangeMatHigh();
        foreach (SimonButton newButton in simonControl.simonButtons)
            newButton.pressable = false;
    }
}
