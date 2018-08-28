using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    string strName;
    string strComment;
    string strCombination;
    string strImage;
    int nStat;
    string strFx;

    public string Name { get { return strName; } }
    public string Comment { get { return strComment; } }
    public string Combination { get { return strCombination; } }
    public string Image { get { return strImage; } }
    public int stat { get { return nStat; } }
    public string fx { get { return strFx; } }

    public Item(string name, string comment, string combination, string img, int stat, string fx)
    {
        Set(name, comment, combination, img, stat, fx);
    }

    public void Set(string name, string comment, string combination, string img, int stat, string fx)
    {
        strName = name;
        strComment = comment;
        strCombination = combination;
        strImage = img;
        nStat = stat;
        strFx = fx;
    }
}

public class Ingredient
{
    public List<ItemManager.eIngredient> m_needBag = new List<ItemManager.eIngredient>();
    string strName;
    string strComment;
    string strImage;
    int nPercent;

    public string Name { get { return strName; } }
    public string Comment { get { return strComment; } }
    public string Image { get { return strImage; } }
    public int Percent { get { return nPercent; } }

    public Ingredient(string name, string comment, string img, int percent)
    {
        Set(name, comment, img, percent);
    }

    public void Set(string name, string comment, string img, int percent)
    {
        strName = name;
        strComment = comment;
        strImage = img;
        nPercent = percent;
    }
}


public class ItemManager : MonoBehaviour {
    public enum eItem { NONE = -1, ShortSword, Shield, Bowgun, Potion, Setting }
    public enum eIngredient { NONE = -1, Slime, Skeleton }
    public List<Item> m_listItems = new List<Item>();
    public List<Ingredient> m_listIngredient = new List<Ingredient>();
    public int itemselect;
    public int ingredientselect;
    // Use this for initialization
    void Start () {
        Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Initialize()
    {
        m_listItems.Add(new Item("숏소드", "매우 허접한 숏소드, 공격력 +10", "슬라임액체x2", "ShortSword", 10, "atk"));
        m_listItems.Add(new Item("쉴드", "매우 허접한 쉴드, 방어력 +10", "슬라임액체x2, 스켈레톤의 골반뼈x1", "Shield", 2, "def"));
        m_listItems.Add(new Item("보우건", "매우 허접한 보우건, 공격럭 +10", "슬라임액체x1, 스켈레톤의 골반뼈x2", "Bowgun", 10, "atk"));
        m_listItems.Add(new Item("포션", "빨간포션, 체력 +20", "없음", "Potion", 10, "hp"));
        m_listItems.Add(new Item("없음", "없음", "없음", "Slime", 0, "etc"));
        m_listIngredient.Add(new Ingredient("슬라임액체", "슬라임을 잡다보면 획득할 수 있다, 잡템", "Slime", 80));
        m_listIngredient.Add(new Ingredient("스켈레톤의 골반뼈", "스켈레톤의 부러진 골반뼈인 듯 하다, 잡템", "Skeleton", 80));
    }


    public Item GetItem(eItem item)
    {
        return m_listItems[(int)item];
    }

    public Ingredient GetIngredient(eIngredient ingredient)
    {
        return m_listIngredient[(int)ingredient];
    }
    //public void Setneedbag()
    //{
    //    m_listItems[0].m_needBag.Add(eIngredient.Slime);
    //    m_listItems[0].m_needBag.Add(eIngredient.Slime);
    //    m_listItems[1].m_needBag.Add(eIngredient.Slime);
    //    m_listItems[1].m_needBag.Add(eIngredient.Slime);
    //    m_listItems[1].m_needBag.Add(eIngredient.Skeleton);
    //    m_listItems[2].m_needBag.Add(eIngredient.Slime);
    //    m_listItems[2].m_needBag.Add(eIngredient.Skeleton);
    //    m_listItems[2].m_needBag.Add(eIngredient.Skeleton);
    //}
    private void OnGUI()
    {
        for (int i = 0; i < m_listItems.Count; i++)
        {
            GUI.Box(new Rect(Screen.width - 100, 20 * i, 100, 20), m_listItems[i].Name);
        }
    }
}
