using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PuzzleLogic : MonoBehaviour
{
    public List<GameObject> puzzleObjects;
    public bool isPassed = false;



    public ObjectTimeEntegration objectTimeEntegration;
    void Start()
    {
        objectTimeEntegration = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<ObjectTimeEntegration>();
        puzzleObjects = objectTimeEntegration.getChilds(this.gameObject);

    }

    void Update()
    {
        if (isPassed)
        {
            Destroy(puzzleObjects[0]);
        }
    }
}
