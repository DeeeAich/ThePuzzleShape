using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverManagement : MonoBehaviour
{

    public List<LeverMove> myLeverEnds = new List<LeverMove>();

    // Update is called once per frame
    void Update()
    {

        foreach (LeverMove lever in myLeverEnds)
        {
            int i = 0;
            foreach (int index in lever.myLever.targets)
            {
                if (i + 1 > lever.myMovers.Count)
                    lever.myMovers.Add(myLeverEnds[index].myLever);
                else
                    lever.myMovers[i] = myLeverEnds[index].myLever;
                i++;
            }
        }

        
    }

    public void ResetLeverEnds()
    {

        foreach (LeverMove lever in myLeverEnds)
            lever.transform.position = lever.transform.parent.position;

    }
}
