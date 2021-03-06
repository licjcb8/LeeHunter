﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {
    public List<GameObject> m_listScene;
    public int Selection = 0;
    public bool Tutorial = true;
    public bool Play = false;
    public enum eSceneStatus { TITLE,TUTORIAL, PLAY, INVENTORY, BAG,EQUIPMENT,COMBINATE,MENU, MAX };
    eSceneStatus m_eCurrentStatus;

    public GUIInventory m_guiInventory;
    public GUIEquipment Guiequipment;
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
            case eSceneStatus.TUTORIAL:
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
            case eSceneStatus.MENU:
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
            case eSceneStatus.TUTORIAL:
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
                else if (Input.GetKeyUp(KeyCode.U))
                {
                    SetStatus(GUIManager.eSceneStatus.EQUIPMENT);
                }
                break;
            case eSceneStatus.PLAY:
                Time.timeScale = 1f;
                Play = true;
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
                else if (Input.GetKeyUp(KeyCode.U))
                {
                    SetStatus(GUIManager.eSceneStatus.EQUIPMENT);
                }
                break;
            case eSceneStatus.INVENTORY:
                Time.timeScale = 0f;
                if (Tutorial == false)
                {
                    if (Input.GetKeyUp(KeyCode.I) || Input.GetKeyUp(KeyCode.Escape))
                    {
                        SetStatus(GUIManager.eSceneStatus.PLAY);
                    }
                }
                if (Tutorial == true)
                {
                    if (Input.GetKeyUp(KeyCode.I) || Input.GetKeyUp(KeyCode.Escape))
                    {
                        SetStatus(GUIManager.eSceneStatus.TUTORIAL);
                    }
                }
                break;
            case eSceneStatus.BAG:
                Time.timeScale = 0f;
                if (Tutorial == false)
                { 
                    if (Input.GetKeyUp(KeyCode.O) || Input.GetKeyUp(KeyCode.Escape))
                    {
                        SetStatus(GUIManager.eSceneStatus.PLAY);
                    }
                }
                if (Tutorial == true)
                {
                    if (Input.GetKeyUp(KeyCode.O) || Input.GetKeyUp(KeyCode.Escape))
                    {
                        SetStatus(GUIManager.eSceneStatus.TUTORIAL);
                    }
                }
                break;
            case eSceneStatus.EQUIPMENT:
                Time.timeScale = 0f;

                if (Tutorial == false)
                {
                    if (Input.GetKeyUp(KeyCode.U) || Input.GetKeyUp(KeyCode.Escape))
                    {
                        SetStatus(GUIManager.eSceneStatus.PLAY);
                    }
                }
                if (Tutorial == true)
                {
                    if (Input.GetKeyUp(KeyCode.U) || Input.GetKeyUp(KeyCode.Escape))
                    {
                        SetStatus(GUIManager.eSceneStatus.TUTORIAL);
                    }
                }
                break;
            case eSceneStatus.COMBINATE:
                Time.timeScale = 0f;

                if (Tutorial == false)
                {
                    if (Input.GetKeyUp(KeyCode.P) || Input.GetKeyUp(KeyCode.Escape))
                    {
                        SetStatus(GUIManager.eSceneStatus.PLAY);
                    }
                }
                if (Tutorial == true)
                {
                    if (Input.GetKeyUp(KeyCode.P) || Input.GetKeyUp(KeyCode.Escape))
                    {
                        SetStatus(GUIManager.eSceneStatus.TUTORIAL);
                    }
                }
                break;
            case eSceneStatus.MENU:
                Time.timeScale = 0f;
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

    public void SetEquipmentButton()
    {
        item = (ItemManager.eItem)GameManager.GetInstance().m_cItemManager.itemselect;
        Item cItem = GameManager.GetInstance().m_cItemManager.GetItem(item);
        Color color;

        if (cItem.fx == "atk")
        {
            Guiequipment.WeaponImg.sprite = Resources.Load<Sprite>("Tex/" + cItem.Image);
            color = Guiequipment.WeaponImg.color;
            color.a = 255f;
            Guiequipment.WeaponImg.color = color;
            player.weaponatk = cItem.stat;
        }
        if (cItem.fx == "armor")
        {
            Guiequipment.ArmorImg.sprite = Resources.Load<Sprite>("Tex/" + cItem.Image);
            color = Guiequipment.ArmorImg.color;
            color.a = 255f;
            Guiequipment.ArmorImg.color = color;
            player.armordef = cItem.stat;
        }
        if (cItem.fx == "shoes")
        {
            Guiequipment.ShoesImg.sprite = Resources.Load<Sprite>("Tex/" + cItem.Image);
            color = Guiequipment.ShoesImg.color;
            color.a = 255f;
            Guiequipment.ShoesImg.color = color;
            player.shoesdef = cItem.stat;
        }
        if (cItem.fx == "helmet")
        {
            Guiequipment.HelmetImg.sprite = Resources.Load<Sprite>("Tex/" + cItem.Image);
            color = Guiequipment.HelmetImg.color;
            color.a = 255f;
            Guiequipment.HelmetImg.color = color;
            player.helmetdef = cItem.stat;
        }
        
    }

    public void MenuButton()
    {
        SetStatus(GUIManager.eSceneStatus.MENU);
    }

    public void GoBackButton()
    {
        if (Tutorial == true)
        {
            SetStatus(GUIManager.eSceneStatus.TUTORIAL);
        }
        if (Tutorial == false)
        {
            SetStatus(GUIManager.eSceneStatus.PLAY);
        }
    }

    public void QuitButton()
    {
        Application.Quit();
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateStatus();
	}
}
