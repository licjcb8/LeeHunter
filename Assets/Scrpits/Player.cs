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

    public Animator animator;
    public float moveSpeed = 5;
    PlayerController controller;
    GunController gunController;
    public AudioClip[] Sound;
    public float accumulator = 0.0f;

    public enum eStatus { NONE = -1, DMG, DEF, HP, EXP, LV }
    public float atk = 20;
    public float def = 2;
    public float hpmax = 100;
    public float hp = 100;
    public int expMax = 100;
    public int exp = 0;
    public int lv = 1;
    public float dmg;
    public int LeftRight = 0; //0=Right 1=Left
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
            animator.SetBool("Hit", false);
            animator.SetBool("Idle", false);
            animator.SetBool("LeftIdle", false);
            if (LeftRight == 1)
            {
                animator.SetTrigger("LeftAttack");
            }
            if (LeftRight == 0)
            {
                animator.SetTrigger("RightAttack");
                
            }
            accumulator += Time.deltaTime;
            if (accumulator >= 1.0f)
            {
                gunController.Shoot();
                accumulator = 0;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            accumulator = 0;
        }
        Dead();
        if (exp >= expMax)
        {
            LVUP();
            SoundPlay(0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            LeftRight = 1;
            animator.SetBool("Hit", false);
            animator.SetBool("RightMove", false);
            animator.SetBool("LeftMove",true);
            animator.SetBool("Idle", false);
            animator.SetBool("LeftIdle", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            LeftRight = 0;
            animator.SetBool("Hit", false);
            animator.SetBool("LeftMove", false);
            animator.SetBool("RightMove", true);
            animator.SetBool("Idle", false);
            animator.SetBool("LeftIdle", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("RightMove", false);
            animator.SetBool("LeftIdle", false);
            animator.SetBool("Idle", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("LeftMove", false);
            animator.SetBool("Idle", false);
            animator.SetBool("LeftIdle", true);
        }
    }

    void Dead()
    {
        if (hp <= 0)
        {
            animator.SetBool("Dead", true);
         //   Destroy(gameObject);
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
        expMax = expMax + 50;
        hp = hpmax;
    }

    public void SoundPlay(int Num)
    {
        GetComponent<AudioSource>().clip = Sound[Num];
        GetComponent<AudioSource>().Play();
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Monster")
        {
            animator.SetBool("Hit", true);
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
            SoundPlay(1);
        }

    }

}

