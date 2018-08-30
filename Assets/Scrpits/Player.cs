using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus
{
    string strStatusName;
    int nStatus;

    public string Name { get { return strStatusName; } }
    public int Status { get { return nStatus; } }

    public CharacterStatus(string Name, int Status)
    {
        Set(Name, Status);
    }

    public void Set(string Name, int Status)
    {
        Name = strStatusName;
        Status = nStatus;
    }

}

[RequireComponent(typeof(GunController))]
[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    List<ItemManager.eItem> m_listInventory = new List<ItemManager.eItem>();
    List<ItemManager.eItem> m_listEquipment = new List<ItemManager.eItem>();
    public List<ItemManager.eIngredient> m_listIngredient = new List<ItemManager.eIngredient>();
    List<CharacterStatus> m_listStatus = new List<CharacterStatus>();

    ItemManager.eItem item;


    public float moveSpeed = 5;
    PlayerController controller;
    GunController gunController;

    public enum eStatus { NONE = -1, DMG, DEF, HP, EXP, LV }
    public float atk = 20;
    public float def = 2;
    public float hpmax = 100;
    public float hp = 100;
    public int exp = 0;
    public int lv = 1;
    public float dmg;

    public int itemselect;

    public void Initialize()
    {
        m_listStatus.Add(new CharacterStatus("데미지", 20));
        m_listStatus.Add(new CharacterStatus("방어력", 2));
        m_listStatus.Add(new CharacterStatus("체력", 100));
        m_listStatus.Add(new CharacterStatus("경험치", 0));
        m_listStatus.Add(new CharacterStatus("레벨", 1));
    }

    public CharacterStatus GetStatus(eStatus status)
    {
        return m_listStatus[(int)status];
    }

    public void SetInventory(ItemManager.eItem item)
    {
        m_listInventory.Add(item);
    }

    public void SetIngredient(ItemManager.eIngredient ingredient)
    {
        m_listIngredient.Add(ingredient);
    }

    public void SetEquip()
    {

        ItemManager.eItem item = (ItemManager.eItem)itemselect;

        Item cItem = GameManager.GetInstance().m_cItemManager.GetItem(item);
        itemselect = (int)item;
        m_listEquipment.Add(item);
    }
    public void SetEquipment()
    {
        item = (ItemManager.eItem)GameManager.GetInstance().m_cItemManager.itemselect;

        Item cItem = GameManager.GetInstance().m_cItemManager.GetItem(item);

        if (cItem.fx == "atk")
        {
            atk = atk + cItem.stat;
        }

        else if (cItem.fx == "def")
        {
            def = def + cItem.stat;
        }
    }
    public ItemManager.eItem GetInventory(ItemManager.eItem item)
    {
        return m_listInventory.Find(obj => obj.Equals(item));
    }

    public ItemManager.eIngredient GetBag(ItemManager.eIngredient ingredient)
    {
        return m_listIngredient.Find(obj => obj.Equals(ingredient));
    }
    public ItemManager.eItem GetEquip(ItemManager.eItem item)
    {
        return m_listEquipment.Find(obj => obj.Equals(item));
    }

    public ItemManager.eItem GetInventory(int idx)
    {
        return m_listInventory[idx];
    }
    public ItemManager.eIngredient GetBag(int idx)
    {
        return m_listIngredient[idx];
    }
    public ItemManager.eItem GetEquip(int idx)
    {
        return m_listEquipment[idx];
    }

    public void DeleteInventory(ItemManager.eItem item)
    {
        m_listInventory.Remove(item);
    }

    public void DeleteBag(ItemManager.eIngredient ingredient)
    {
        m_listIngredient.Remove(ingredient);
    }

    public void DeleteEquip(ItemManager.eItem item)
    {
        m_listEquipment.Remove(item);
    }
    public int GetInventorySize()
    {
        return m_listInventory.Count;
    }

    public int GetBagSize()
    {
        return m_listIngredient.Count;
    }
    public int GetEquipSize()
    {
        return m_listEquipment.Count;
    }


    void Start()
    {
        controller = GetComponent<PlayerController>();
        gunController = GetComponent<GunController>();
    }



    void Update()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);
        if (Input.GetMouseButton(0))
        {

            gunController.Shoot();

        }
        Dead();
        if (exp == 100)
        {
            LVUP();
        }
    }

    void Dead()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void LVUP()
    {
        exp = 0;
        lv++;
        Debug.Log("Level up!");
        atk = atk + 10;
        def = def + 2;
        hpmax = hpmax + 50;
        hp = hpmax;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Monster")
        {
            dmg = collision.gameObject.GetComponent<Monster>().atk;
            if (dmg <= 0)
            {
                dmg = 0;
            }
            hp = hp - dmg;
        }

        if (collision.collider.tag == "Item")
        {
            Destroy(collision.gameObject);
        }

    }

}

