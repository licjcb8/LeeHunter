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
    public GameObject Tutorial6;
    public GameObject Tutorial7;
    public GameObject Tutorial8;
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
        if (TutorialStatus == 4)
        {
            Tutorial4.SetActive(false);
            Tutorial5.SetActive(true);
        }
        if (TutorialStatus == 5)
        {
            Tutorial5.SetActive(false);
            Tutorial6.SetActive(true);
        }
        if (TutorialStatus == 6)
        {
            Tutorial6.SetActive(false);
            Tutorial7.SetActive(true);
        }
        if (TutorialStatus == 7)
        {
            Tutorial7.SetActive(false);
            Tutorial8.SetActive(true);
        }
        if (TutorialStatus == 8)
        {
            Tutorial8.SetActive(false);
            GameManager.GetInstance().m_cGUIManager.SetStatus(GUIManager.eSceneStatus.PLAY);
        }
    }
}
