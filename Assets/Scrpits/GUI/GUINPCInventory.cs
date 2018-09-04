using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GUINPCInventory : MonoBehaviour
{

    public GUIItemList m_cItemList;
    public GUIPanel m_cPanel;
    public Player player;

    ItemManager.eItem item;
    ItemManager.eIngredient ingredient;
    public int Check = 0;
    public int equalornot = 1;

    public void SetInventory(NPC npc)
    {
        m_cItemList.ReleaseItems();
        for (int i = 0; i < npc.GetInventorySize(); i++)
            m_cItemList.AddCombination(npc.GetInventory(i), m_cPanel);
        m_cItemList.SetContextSize();
    }

    public void SetPanel(ItemManager.eItem item)
    {
        m_cPanel.Set(item);
    }

    public void BuyItem()
    {
        item = (ItemManager.eItem)GameManager.GetInstance().m_cItemManager.itemselect;
        Item cItem = GameManager.GetInstance().m_cItemManager.GetItem(item);
        player.SetInventory(item);
    }



    public void CombinateItem()
    {
        item = (ItemManager.eItem)GameManager.GetInstance().m_cItemManager.itemselect;
        Item cItem = GameManager.GetInstance().m_cItemManager.GetItem(item);

        var firstNotSecond = GameManager.GetInstance().m_cItemManager.GetItem(item).m_needBag.Except(GameManager.GetInstance().m_cNPC.m_listBag).ToList();
        var secondNotFirst = GameManager.GetInstance().m_cNPC.m_listBag.Except(GameManager.GetInstance().m_cItemManager.GetItem(item).m_needBag).ToList();
        if (!firstNotSecond.Any() && !secondNotFirst.Any())
        {
            player.SetInventory(item);
            GameManager.GetInstance().m_cNPC.ReleaseItems();
        }
        GameManager.GetInstance().m_cGUIManager.SetStatus(GUIManager.eSceneStatus.COMBINATE);
    }




    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

