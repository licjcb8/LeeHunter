using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIBag : MonoBehaviour
{
    public GUIItemList m_cItemList;
    public GUIPanel m_cPanel;
    // Use this for initialization
    public void SetBag(Player player)
    {
        m_cItemList.ReleaseItems();
        for (int i = 0; i < player.GetBagSize(); i++)
            m_cItemList.AddIngredient(player.GetBag(i), m_cPanel);
        m_cItemList.SetContextSize();
    }

    public void SetPanel(ItemManager.eIngredient ingredient)
    {
        m_cPanel.SetIngredient(ingredient);
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}