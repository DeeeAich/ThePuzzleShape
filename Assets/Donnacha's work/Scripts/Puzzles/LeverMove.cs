using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverMove : MonoBehaviour
{

    public LeverClass myLever;
    public List<LeverClass> myMovers;

    public List<float> angles = new List<float>();

    public bool held = false;

    public LeverManagement leverManager;

    public void Grabbed()
    {
        held = true;
    }

    public void LetGoOf()
    {
        held = false;
        int indexChange = NearestIndex() - myLever.currentIndex;

        myLever.currentIndex = NearestIndex();
        Quaternion quaternion = Quaternion.Euler(angles[myLever.currentIndex], 0, 0);
        myLever.SetLocalRotation(quaternion);
        transform.position = transform.parent.position;

        foreach(LeverClass lever in myMovers)
            if (myLever.isPos) lever.ReflectiveMove(indexChange);
            else lever.ReflectiveMove(-indexChange);
        
    }

    private void Update()
    {
        if (held)
        {
            Quaternion nextRotation = Quaternion.LookRotation(transform.localPosition - myLever.myBody.transform.localPosition, myLever.myBody.transform.up);
            //Debug.Log(nextRotation);

            nextRotation = Quaternion.Euler(Mathf.Clamp(nextRotation.x * Mathf.Rad2Deg * 2,angles[2], angles[0]), 0, 0);

            myLever.SetLocalRotation(nextRotation);
        }
    }

    private int NearestIndex()
    {
        int index = 0;
        for (int i = 1; i < 3; i++)
            if (myLever.myBody.transform.rotation.x > angles[i] - 30 && myLever.myBody.transform.rotation.x < angles[i] + 30)
                index = i;

        return index;
    }

}
