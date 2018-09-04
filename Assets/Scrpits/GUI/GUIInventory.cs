using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIInventory : MonoBehaviour
{
    public GUIItemList m_cItemList;
    public GUIPanel m_cPanel;
    

    public void SetInventory(Player player)
    {
        m_cItemList.ReleaseItems();
        for (int i = 0; i < player.GetInventorySize(); i++)
            m_cItemList.AddItem(player.GetInventory(i), m_cPanel);
        m_cItemList.SetContextSize();
    }

    public void SetPanel(ItemManager.eItem item)
    {
        m_cPanel.Set(item);
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