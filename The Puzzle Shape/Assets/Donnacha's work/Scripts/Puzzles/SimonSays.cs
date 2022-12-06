using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays : MonoBehaviour
{

    public List<SimonButton> simonButtons = new List<SimonButton>();
    public bool onHold;
    public List<int> order = new List<int>();
    int completionCount;
    int currentCount;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++)
            order.Add(Random.Range(0, 3));
    }

    public void StartSimon()
    {
        if (!onHold)
            return;
        completionCount = 0;
        currentCount = 0;
        foreach (SimonButton button in simonButtons)
            button.pressable = false;
        //begins round 1
        
        NextSimon();
    }

    public void NextSimon()
    {

        if (currentCount < 2 + completionCount * 2)
        {
            int index = order[currentCount];
            Debug.Log(index);
            simonButtons[index].PressedByParent();
            currentCount++;
        }
        else
        {
            foreach (SimonButton button in simonButtons)
                button.pressable = true;
            currentCount = 0;
            onHold = false;
        }
    }

    public void CheckButton(SimonButton button)
    {

        if (button.i == order[currentCount])
        { 
            currentCount++;
            if(currentCount == 2 + completionCount * 2)
            {
                currentCount = 0;
                completionCount++;
                foreach (SimonButton newbutton in simonButtons)
                    newbutton.pressable = false;
                onHold = true;
                NextSimon();
            }
        }
        else
        {
            currentCount = 0;
            completionCount = 0;
            onHold = true;
        }
    }

}
