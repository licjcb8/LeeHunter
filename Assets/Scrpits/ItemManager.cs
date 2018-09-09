using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public List<ItemManager.eIngredient> m_needBag = new List<ItemManager.eIngredient>();
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
    public enum eItem { NONE = -1, WoodBow, BoneBow, Bowgun,ElnfinBow ,DemonBow,DragonBow,WoodHelmet,WoodArmor,BoneHelmet,BoneArmor,DragonHelmet,DragonArmor }
    public enum eIngredient { NONE = -1, Slime, Skeleton,Wood,DemonHeart,DragonBall }
    public List<Item> m_listItems = new List<Item>();
    public List<Ingredient> m_listIngredient = new List<Ingredient>();
    public int itemselect;
    public int ingredientselect;
    // Use this for initialization
    void Start () {
        Initialize();
        Setneedbag();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Initialize()
    {
        m_listItems.Add(new Item("나무활", "매우 허접한 활, 공격력 +10", "나무판자x2", "WoodBow", 10, "atk"));
        m_listItems.Add(new Item("본보우", "스켈레톤의 뼈로 만든 활, 공격력 +15", "나무판자x1, 스켈레톤의 골반뼈x2", "BoneBow", 15, "atk"));
        m_listItems.Add(new Item("보우건", "매우 허접한 보우건, 공격럭 +20", "슬라임액체x1, 스켈레톤의 골반뼈x2", "Bowgun", 20, "atk"));
        m_listItems.Add(new Item("엘프의활", "엘프들의 기운이 깃든 활, 공격력 +25", "나무판자x4, 슬라임액체x4", "ElfinBow", 25, "atk"));
        m_listItems.Add(new Item("데몬보우", "악마의 활 그 자체", "스켈레톤의 골반뼈x2, 데몬하트x2", "DemonBow", 30, "atk"));
        m_listItems.Add(new Item("드래곤보우", "드래곤의 힘이 깃들어 있다", "스켈레톤의 골반뼈x2, 데몬하트x2, 드래곤볼x2", "DragonBow", 35, "atk"));
        m_listItems.Add(new Item("나무투구", "매우 허접한 투구, 방어력 +3", "나무판자x3", "WoodHelmet", 3, "helmet"));
        m_listItems.Add(new Item("나무갑옷", "매우 허접한 갑옷, 방어력 +5", "나무판자x4", "WoodArmor", 5, "armor"));
        m_listItems.Add(new Item("해골투구", "뼈로 이루어진 투구 허술해 보인다, 방어력 +5", "나무판자x1 스켈레톤의 골반뼈x2", "BoneHelmet", 5, "helmet"));
        m_listItems.Add(new Item("해골갑옷", "뼈로 이루어진 갑옷 조금은 튼튼해 보인다, 방어력 +7", "나무판자x2 스켈레톤의 골반뼈x3", "BoneArmor",7, "armor"));
        m_listItems.Add(new Item("드래곤투구", "드래곤의 정수가 들어간 투구, 방어력 +10", "데몬하트 x1 드래곤볼 x3", "DragonHelmet", 10, "helmet"));
        m_listItems.Add(new Item("드래곤갑옷", "드래곤의 힘을 가진 갑옷, 방어력 +15", "데몬하트x2 드래곤볼x4", "DragonArmor", 15, "armor"));
        m_listIngredient.Add(new Ingredient("슬라임액체", "슬라임을 잡다보면 획득할 수 있다, 잡템", "Slime", 80));
        m_listIngredient.Add(new Ingredient("스켈레톤의 골반뼈", "스켈레톤의 부러진 골반뼈인 듯 하다, 잡템", "Skeleton", 80));
        m_listIngredient.Add(new Ingredient("나무판자", "흔히 구할 수 있는 나무조각, 잡템", "Wood", 100));
        m_listIngredient.Add(new Ingredient("데몬하트", "악마의 심장, 잡템", "DemonHeart", 60));
        m_listIngredient.Add(new Ingredient("드래곤볼", "용의 정수, 잡템", "DragonBall", 40));
    }


    public Item GetItem(eItem item)
    {
        return m_listItems[(int)item];
    }

    public Ingredient GetIngredient(eIngredient ingredient)
    {
        return m_listIngredient[(int)ingredient];
    }
    public void Setneedbag()
    {
        m_listItems[0].m_needBag.Add(eIngredient.Wood);
        m_listItems[0].m_needBag.Add(eIngredient.Wood);
        //나무활
        m_listItems[1].m_needBag.Add(eIngredient.Wood);
        m_listItems[1].m_needBag.Add(eIngredient.Skeleton);
        m_listItems[1].m_needBag.Add(eIngredient.Skeleton);
        //본보우
        m_listItems[2].m_needBag.Add(eIngredient.Slime);
        m_listItems[2].m_needBag.Add(eIngredient.Skeleton);
        m_listItems[2].m_needBag.Add(eIngredient.Skeleton);
        //보우건
        m_listItems[3].m_needBag.Add(eIngredient.Wood);
        m_listItems[3].m_needBag.Add(eIngredient.Wood);
        m_listItems[3].m_needBag.Add(eIngredient.Wood);
        m_listItems[3].m_needBag.Add(eIngredient.Wood);
        m_listItems[3].m_needBag.Add(eIngredient.Slime);
        m_listItems[3].m_needBag.Add(eIngredient.Slime);
        m_listItems[3].m_needBag.Add(eIngredient.Slime);
        m_listItems[3].m_needBag.Add(eIngredient.Slime);
        //엘프의활
        m_listItems[4].m_needBag.Add(eIngredient.Skeleton);
        m_listItems[4].m_needBag.Add(eIngredient.Skeleton);
        m_listItems[4].m_needBag.Add(eIngredient.DemonHeart);
        m_listItems[4].m_needBag.Add(eIngredient.DemonHeart);
        //데몬보우
        m_listItems[5].m_needBag.Add(eIngredient.Skeleton);
        m_listItems[5].m_needBag.Add(eIngredient.Skeleton);
        m_listItems[5].m_needBag.Add(eIngredient.DemonHeart);
        m_listItems[5].m_needBag.Add(eIngredient.DemonHeart);
        m_listItems[5].m_needBag.Add(eIngredient.DragonBall);
        m_listItems[5].m_needBag.Add(eIngredient.DragonBall);
        //드래곤보우
        m_listItems[6].m_needBag.Add(eIngredient.Wood);
        m_listItems[6].m_needBag.Add(eIngredient.Wood);
        m_listItems[6].m_needBag.Add(eIngredient.Wood);
        //나무투구
        m_listItems[7].m_needBag.Add(eIngredient.Wood);
        m_listItems[7].m_needBag.Add(eIngredient.Wood);
        m_listItems[7].m_needBag.Add(eIngredient.Wood);
        m_listItems[7].m_needBag.Add(eIngredient.Wood);
        //나무갑옷
        m_listItems[8].m_needBag.Add(eIngredient.Wood);
        m_listItems[8].m_needBag.Add(eIngredient.Skeleton);
        m_listItems[8].m_needBag.Add(eIngredient.Skeleton);
        //해골투구
        m_listItems[9].m_needBag.Add(eIngredient.Wood);
        m_listItems[9].m_needBag.Add(eIngredient.Wood);
        m_listItems[9].m_needBag.Add(eIngredient.Skeleton);
        m_listItems[9].m_needBag.Add(eIngredient.Skeleton);
        m_listItems[9].m_needBag.Add(eIngredient.Skeleton);
        //해골갑옷
        m_listItems[10].m_needBag.Add(eIngredient.DemonHeart);
        m_listItems[10].m_needBag.Add(eIngredient.DragonBall);
        m_listItems[10].m_needBag.Add(eIngredient.DragonBall);
        m_listItems[10].m_needBag.Add(eIngredient.DragonBall);
        //드래곤투구
        m_listItems[11].m_needBag.Add(eIngredient.DemonHeart);
        m_listItems[11].m_needBag.Add(eIngredient.DemonHeart);
        m_listItems[11].m_needBag.Add(eIngredient.DragonBall);
        m_listItems[11].m_needBag.Add(eIngredient.DragonBall);
        m_listItems[11].m_needBag.Add(eIngredient.DragonBall);
        m_listItems[11].m_needBag.Add(eIngredient.DragonBall);
        //드래곤갑옷
    }
    //private void OnGUI()
    //{
    //    for (int i = 0; i < m_listItems.Count; i++)
    //    {
    //        GUI.Box(new Rect(Screen.width - 100, 20 * i, 100, 20), m_listItems[i].Name);
    //    }
    //}
}
