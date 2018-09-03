using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class GameManager : MonoBehaviour {
    public Player m_cPlayer;
    public NPC m_cNPC;
    static GameManager m_cInstance;
    public ItemManager m_cItemManager;
    public GUIManager m_cGUIManager;
    public GUIManager.eSceneStatus m_eSceneStatus;
    

    static public GameManager GetInstance()
    {
        return m_cInstance;
    }
    // Use this for initialization
    void Start()
    {
        m_cInstance = this;
        m_cGUIManager.SetStatus(m_eSceneStatus);

    }

    public void EventStart()
    {

        m_cGUIManager.SetStatus(GUIManager.eSceneStatus.PLAY);
    }

    public void EventExit()
    {
        Application.Quit();
    }

    public void EventTheEnd()
    {
     //   m_cGUIManager.SetStatus(GUIManager.eSceneStatus.THEEND);
    }

    public void EventGameOver()
    {
     //   m_cGUIManager.SetStatus(GUIManager.eSceneStatus.GAMEOVER);
    }


    // Update is called once per frame
    void Update () {
		
	}
}
