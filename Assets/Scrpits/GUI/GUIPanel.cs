using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIPanel : MonoBehaviour
{
    public Image m_cImage;
    public Text m_cText;
    // Use this for initialization

    public void Set(ItemManager.eItem item)
    {

        Item cItem = GameManager.GetInstance().m_cItemManager.GetItem(item);
        m_cImage.sprite = Resources.Load<Sprite>("Tex/" + cItem.Image);
        m_cText.text = cItem.Comment;
        GameManager.GetInstance().m_cItemManager.itemselect = (int)item;
    }

    public void SetIngredient(ItemManager.eIngredient ingredient)
    {
        Ingredient cIngredient = GameManager.GetInstance().m_cItemManager.GetIngredient(ingredient);
        m_cImage.sprite = Resources.Load<Sprite>("Tex/" + cIngredient.Image);
        m_cText.text = cIngredient.Comment;
        GameManager.GetInstance().m_cItemManager.ingredientselect = (int)ingredient;

    }

    public void SetCombination(ItemManager.eItem item)
    {

        Item cItem = GameManager.GetInstance().m_cItemManager.GetItem(item);
        m_cText.text = cItem.Combination;
        GameManager.GetInstance().m_cItemManager.itemselect = (int)item;
    }


    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 40, 100, 20), "GUIPanel"))
        {
            Set(ItemManager.eItem.ShortSword);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}