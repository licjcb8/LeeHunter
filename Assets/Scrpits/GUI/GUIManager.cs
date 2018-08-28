using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {
    public List<GameObject> m_listScene;
    public int Selection = 0;
    public enum eSceneStatus { TITLE, PLAY, INVENTORY, EQUIPMENT,COMBINATE, MAX };
    eSceneStatus m_eCurrentStatus;
    // Use this for initialization

    public void SetStatus(eSceneStatus status)
    {
        switch (status)
        {
            case eSceneStatus.TITLE:
                break;
            case eSceneStatus.PLAY:
                break;
            case eSceneStatus.INVENTORY:
                break;
            case eSceneStatus.EQUIPMENT:
                break;
            case eSceneStatus.COMBINATE:
                break;
        }
    }

    public void UpdateStatus()
    {
        switch (m_eCurrentStatus)
        {
            case eSceneStatus.TITLE:
                break;
            case eSceneStatus.PLAY:
                break;
            case eSceneStatus.INVENTORY:
                break;
            case eSceneStatus.EQUIPMENT:
                break;
            case eSceneStatus.COMBINATE:
                break;
        }
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
