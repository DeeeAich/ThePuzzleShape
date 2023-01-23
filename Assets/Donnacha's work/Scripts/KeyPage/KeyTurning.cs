using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyTurning : MonoBehaviour
{
    public Transform keyGameobject;
    public bool allFinished;
    // Update is called once per frame

    private void Start()
    {
        PuzzleManager.PuzzleControl().gameFinished = this;
    }

    void FixedUpdate()
    {
        if (allFinished)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, transform.localRotation * Quaternion.Euler(90, 0, 0), Time.deltaTime * 60); ;
            keyGameobject.localRotation = transform.localRotation;
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(0);
    }
}
