using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    private static PuzzleManager puzzleControl;
    public static PuzzleManager PuzzleControl()
    {
        if (puzzleControl == null)
        {
            puzzleControl = GameObject.Instantiate(new GameObject()).AddComponent<PuzzleManager>();

        }
        return puzzleControl;
    }

    public int puzzleCompleted = 0;
    int puzzleCount = 2;

    public KeyTurning gameFinished;
    private void Update()
    {

        if (puzzleCompleted == puzzleCount && !gameFinished.allFinished)
            gameFinished.allFinished = true;

    }
}
