using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public PuzzleLogic puzzleLogic;
    void Start()
    {
        puzzleLogic = GameObject.FindGameObjectWithTag("ProgressManager").GetComponent<PuzzleLogic>();
   
    }

    private void OnTriggerEnter(Collider other)
    {
        puzzleLogic.isPassed = true;
    }
}
