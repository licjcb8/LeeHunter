using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GUIItemList : MonoBehaviour
{
    List<GameObject> m_listItemList = new List<GameObject>();
    public GameObject m_prefabButton;
    public GameObject m_objContext;

    public void AddItem(ItemManager.eItem item, GUIPanel cPanel)
    {
        Item cItem = GameManager.GetInstance().m_cItemManager.GetItem(item);
        GameObject objButton = Instantiate(m_prefabButton);
        GUIItemButton cItemButton = objButton.GetComponent<GUIItemButton>();
        Button btnButton = objButton.GetComponent<Button>();
        btnButton.onClick.AddListener(() => cPanel.Set(item));
        cItemButton.m_cText.text = cItem.Name;
        objButton.transform.SetParent(m_objContext.transform);
        m_listItemList.Add(objButton);
    }
    public void AddIngredient(ItemManager.eIngredient ingredient, GUIPanel cPanel)
    {
        Ingredient cIngredient = GameManager.GetInstance().m_cItemManager.GetIngredient(ingredient);
        GameObject objButton = Instantiate(m_prefabButton);
        GUIItemButton cItemButton = objButton.GetComponent<GUIItemButton>();
        Button btnButton = objButton.GetComponent<Button>();
        btnButton.onClick.AddListener(() => cPanel.SetIngredient(ingredient));
        cItemButton.m_cText.text = cIngredient.Name;
        objButton.transform.SetParent(m_objContext.transform);
        m_listItemList.Add(objButton);
    }

    public void AddCombination(ItemManager.eItem item, GUIPanel cPanel)
    {
        Item cItem = GameManager.GetInstance().m_cItemManager.GetItem(item);
        GameObject objButton = Instantiate(m_prefabButton);
        GUIItemButton cItemButton = objButton.GetComponent<GUIItemButton>();
        Button btnButton = objButton.GetComponent<Button>();
        btnButton.onClick.AddListener(() => cPanel.SetCombination(item));
        cItemButton.m_cText.text = cItem.Name;
        objButton.transform.SetParent(m_objContext.transform);
        m_listItemList.Add(objButton);
    }

    public void DeleteItem(int idx)
    {
        GameObject button = m_listItemList[idx];
        m_listItemList.Remove(m_listItemList[idx]);
        Destroy(button);
    }

    public void ReleaseItems()
    {
        for (int i = m_listItemList.Count - 1; i >= 0; i--)
            DeleteItem(i);
        m_listItemList.Clear();
    }

    public void SetContextSize()
    {
        RectTransform rectContext = m_objContext.GetComponent<RectTransform>();
        GridLayoutGroup grid = m_objContext.GetComponent<GridLayoutGroup>();
        int nSize = m_listItemList.Count;
       int nContextHeight = (int)(grid.cellSize.y * nSize);
       rectContext.sizeDelta = new Vector2(rectContext.sizeDelta.x, nContextHeight);
    }

    private void OnGUI()
    {

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