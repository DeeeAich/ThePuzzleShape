using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineConnection : MonoBehaviour
{

    public LineRenderer lineControl;

    public GameObject lineBase;
    public float lineRange;
    private List<GameObject> gears = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

        lineControl = GetComponent<LineRenderer>();

        lineControl.SetPosition(0, transform.position);

    }

    // Update is called once per frame
    void Update()
    {

        lineControl.SetPosition(lineControl.positionCount - 1, lineBase.transform.position);

    }

    public void Clear()
    {

        gears.Clear();

        lineControl.positionCount = 2;

    }

    public void AddLinePoint(GameObject newGear)
    {

        RaycastHit hit;
        if (gears.Contains(newGear) )
            return;

        if(Physics.Raycast(newGear.transform.position,  lineControl.GetPosition(lineControl.positionCount -2) - newGear.transform.position, out hit))
        {
            Debug.Log(hit.transform.name);

            if (hit.transform.name == "Blocker")
                return;
        }

        lineControl.SetPosition(lineControl.positionCount - 1, newGear.transform.position + new Vector3(0, 0, lineRange));
        lineControl.positionCount += 1;
        gears.Add(newGear);
        
    }
}
