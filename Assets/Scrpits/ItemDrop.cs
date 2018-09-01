using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public ItemManager.eIngredient m_eIngredient;
    // Use this for initialization


    public void GiveItem()
    {

        GameManager.GetInstance().m_cPlayer.SetIngredient(m_eIngredient);
    }


    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            GiveItem();
            Debug.Log("Item Get!");
        }
    }
}
