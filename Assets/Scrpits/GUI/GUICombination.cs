using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUICombination : MonoBehaviour
{
    List<GameObject> m_listItemList = new List<GameObject>();
    public GameObject m_prefabButton;
    public GameObject m_objContext;

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


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}