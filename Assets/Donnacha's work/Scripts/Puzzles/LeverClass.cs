using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class LeverClass 
{

    public int currentIndex;
    public bool isPos;
    public GameObject myBody;
    public List<int> targets = new List<int>();

    public void SetLocalRotation(Quaternion newRotation)
    {

        myBody.transform.localRotation = newRotation;

    }

    public void ReflectiveMove(int angleChange)
    {
        currentIndex += angleChange;
        if (currentIndex < 0)
            currentIndex = 0;
        if (currentIndex > 2)
            currentIndex = 2;

        if (currentIndex == 0)
            SetLocalRotation(Quaternion.Euler(-60, 0, 0));
        if (currentIndex == 1)
            SetLocalRotation(Quaternion.Euler(0, 0, 0));
        if (currentIndex == 2)
            SetLocalRotation(Quaternion.Euler(60, 0, 0));
    }
}
