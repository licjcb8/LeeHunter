using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {
    public List<GameObject> m_listScene;
    public int Selection = 0;
    public enum eSceneStatus { TITLE, PLAY, INVENTORY, BAG,EQUIPMENT,COMBINATE, MAX };
    eSceneStatus m_eCurrentStatus;

    public GUIInventory m_guiInventory;
    public Player player;

    ItemManager.eIngredient ingredient;
    ItemManager.eItem item;

    void SetInventory()
    {
        if (!m_guiInventory.gameObject.activeSelf)
        {
            m_guiInventory.SetInventory(GameManager.GetInstance().m_cPlayer);
            m_guiInventory.gameObject.SetActive(true);
        }
        else
        {
            m_guiInventory.gameObject.SetActive(false);
        }
    }


    public void SetStatus(eSceneStatus status)
    {
        switch (status)
        {
            case eSceneStatus.TITLE:
                break;
            case eSceneStatus.PLAY:
                break;
            case eSceneStatus.INVENTORY:
                GUIInventory inventory = m_listScene[(int)eSceneStatus.INVENTORY].GetComponent<GUIInventory>();
                inventory.SetInventory(GameManager.GetInstance().m_cPlayer);
                break;
            case eSceneStatus.BAG:
                GUIBag bag = m_listScene[(int)eSceneStatus.BAG].GetComponent<GUIBag>();
                bag.SetBag(GameManager.GetInstance().m_cPlayer);
                break;
            case eSceneStatus.EQUIPMENT:
                break;
            case eSceneStatus.COMBINATE:
                break;
        }
        ShowScene(status);
        m_eCurrentStatus = status;
    }

    public void UpdateStatus()
    {
        switch (m_eCurrentStatus)
        {
            case eSceneStatus.TITLE:
                break;
            case eSceneStatus.PLAY:
                if (Input.GetKeyUp(KeyCode.I))
                {
                    SetStatus(GUIManager.eSceneStatus.INVENTORY);
                }
                else if (Input.GetKeyUp(KeyCode.O))
                {
                    SetStatus(GUIManager.eSceneStatus.BAG);
                }
                break;
            case eSceneStatus.INVENTORY:
                if (Input.GetKeyUp(KeyCode.I)||Input.GetKeyUp(KeyCode.Escape))
                {
                    SetStatus(GUIManager.eSceneStatus.PLAY);
                }
                break;
            case eSceneStatus.BAG:
                if (Input.GetKeyUp(KeyCode.O))
                {
                    SetStatus(GUIManager.eSceneStatus.PLAY);
                }
                break;
            case eSceneStatus.EQUIPMENT:
                break;
            case eSceneStatus.COMBINATE:
                break;
        }
    }

    public GameObject GetScene(eSceneStatus status)
    {
        return m_listScene[(int)status];
    }


    public void ShowScene(eSceneStatus status)
    {
        for (eSceneStatus e = 0; e < eSceneStatus.MAX; e++)
        {
            if (status == e)
                m_listScene[(int)e].SetActive(true);
            else
                m_listScene[(int)e].SetActive(false);
        }
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateStatus();
	}
}
