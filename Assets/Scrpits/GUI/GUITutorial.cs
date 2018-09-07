using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUITutorial : MonoBehaviour {
    public int TutorialStatus =0;
    public GameObject Tutorial1;
    public GameObject Tutorial2;
    public GameObject Tutorial3;
    public GameObject Tutorial4;
    public GameObject Tutorial5;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            TutorialStatus++;
        }
        if (TutorialStatus == 0)
        {
            Tutorial1.SetActive(true);
        }
        if (TutorialStatus == 1)
        {
            Tutorial1.SetActive(false);
            Tutorial2.SetActive(true);
        }
        if (TutorialStatus == 2)
        {
            Tutorial2.SetActive(false);
            Tutorial3.SetActive(true);
        }
        if (TutorialStatus == 3)
        {
            Tutorial3.SetActive(false);
            Tutorial4.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.O))
        {
            TutorialStatus = 4;
        }
        if (TutorialStatus == 4)
        {
            Tutorial4.SetActive(false);
            Tutorial5.SetActive(true);
        }
    }
}
