using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    List<ItemManager.eItem> m_listInventory = new List<ItemManager.eItem>();
    public List<ItemManager.eIngredient> m_listBag = new List<ItemManager.eIngredient>();
    ItemManager.eIngredient ingredient;
    // Use this for initialization
    public void SetIventory()
    {
        m_listInventory.Add(ItemManager.eItem.WoodBow);
        m_listInventory.Add(ItemManager.eItem.BoneBow);
        m_listInventory.Add(ItemManager.eItem.Bowgun);
        m_listInventory.Add(ItemManager.eItem.ElnfinBow);
        m_listInventory.Add(ItemManager.eItem.DemonBow);
        m_listInventory.Add(ItemManager.eItem.DragonBow);
    }

    public void SetBag(ItemManager.eIngredient ingredient)
    {
        m_listBag.Add(ingredient);
    }

    public void DeleteBag(ItemManager.eIngredient ingredient)
    {
        m_listBag.Remove(ingredient);
    }

    public ItemManager.eItem GetInventory(ItemManager.eItem item)
    {
        return m_listInventory.Find(obj => obj.Equals(item));
    }

    public ItemManager.eItem GetInventory(int idx)
    {
        return m_listInventory[idx];
    }

    public void DeleteInvetory(ItemManager.eItem item)
    {
        m_listInventory.Remove(item);
    }

    public int GetInventorySize()
    {
        return m_listInventory.Count;
    }

    public ItemManager.eIngredient GetBag(ItemManager.eIngredient ingredient)
    {
        return m_listBag.Find(obj => obj.Equals(ingredient));
    }

    public ItemManager.eIngredient GetBag(int idx)
    {
        return m_listBag[idx];
    }

    public void ReleaseItems()
    {
        for (int i = m_listBag.Count - 1; i >= 0; i--)
        {
            m_listBag.Remove(m_listBag[i]);
            m_listBag.Clear();
        }
    }

    public int GetBagSize()
    {
        return m_listBag.Count;
    }

    void Start()
    {
        SetIventory();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
