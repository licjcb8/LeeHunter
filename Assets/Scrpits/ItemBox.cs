using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemBox : MonoBehaviour
{
    public ItemManager.eIngredient m_eIngredient;

    public int Rndrop;
    public bool Drop = false;
    public void GiveItem(Player player)
    {
        Rndrop = Random.Range(0, 100);
        for (int i = 0; i < GameManager.GetInstance().m_cItemManager.GetIngredient(m_eIngredient).Percent; i++)
        {
            if (i == Rndrop)
                Drop = true;
        }
     

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
