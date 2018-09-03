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
    public NPC npc;

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
                inventory.  SetInventory(GameManager.GetInstance().m_cPlayer);
                break;
            case eSceneStatus.BAG:
                GUIBag bag = m_listScene[(int)eSceneStatus.BAG].GetComponent<GUIBag>();
                bag.SetBag(GameManager.GetInstance().m_cPlayer);
                break;
            case eSceneStatus.EQUIPMENT:
                break;
            case eSceneStatus.COMBINATE:
                GUIBag bag1 = m_listScene[(int)eSceneStatus.COMBINATE].GetComponent<GUIBag>();
                bag1.SetBag(GameManager.GetInstance().m_cPlayer);
                GUINPCBag bag2 = m_listScene[(int)eSceneStatus.COMBINATE].GetComponent<GUINPCBag>();
                bag2.SetNPCBag(GameManager.GetInstance().m_cNPC);
                GUINPCInventory NPCInventory2 = m_listScene[(int)eSceneStatus.COMBINATE].GetComponent<GUINPCInventory>();
                NPCInventory2.SetInventory(GameManager.GetInstance().m_cNPC);
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
                Time.timeScale = 0f;
                break;
            case eSceneStatus.PLAY:
                Time.timeScale = 1f;

                if (Input.GetKeyUp(KeyCode.I))
                {
                    SetStatus(GUIManager.eSceneStatus.INVENTORY);
                }
                else if (Input.GetKeyUp(KeyCode.O))
                {
                    SetStatus(GUIManager.eSceneStatus.BAG);
                }
                else if (Input.GetKeyUp(KeyCode.P))
                {
                    SetStatus(GUIManager.eSceneStatus.COMBINATE);
                }
                break;
            case eSceneStatus.INVENTORY:
                Time.timeScale = 0f;

                if (Input.GetKeyUp(KeyCode.I)||Input.GetKeyUp(KeyCode.Escape))
                {
                    SetStatus(GUIManager.eSceneStatus.PLAY);
                }
                break;
            case eSceneStatus.BAG:
                Time.timeScale = 0f;

                if (Input.GetKeyUp(KeyCode.O) || Input.GetKeyUp(KeyCode.Escape))
                {
                    SetStatus(GUIManager.eSceneStatus.PLAY);
                }
                break;
            case eSceneStatus.EQUIPMENT:
                break;
            case eSceneStatus.COMBINATE:
                Time.timeScale = 0f;

                if (Input.GetKeyUp(KeyCode.P) || Input.GetKeyUp(KeyCode.Escape))
                {
                    SetStatus(GUIManager.eSceneStatus.PLAY);
                }
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

    public void InputItem()
    {
        ingredient = (ItemManager.eIngredient)GameManager.GetInstance().m_cItemManager.ingredientselect;
        Ingredient cIngredient = GameManager.GetInstance().m_cItemManager.GetIngredient(ingredient);
        npc.SetBag(ingredient);
        player.DeleteBag(ingredient);
        SetStatus(eSceneStatus.COMBINATE);
    }

    public void OutputItem()
    {
        ingredient = (ItemManager.eIngredient)GameManager.GetInstance().m_cItemManager.ingredientselect;
        Ingredient cIngredient = GameManager.GetInstance().m_cItemManager.GetIngredient(ingredient);
        npc.DeleteBag(ingredient);
        player.SetIngredient(ingredient);
        SetStatus(eSceneStatus.COMBINATE);
    }


    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateStatus();
	}
}
