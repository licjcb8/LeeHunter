using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public Player player;

    public Text HPText;

    // Use this for initialization
    void Start()
    {
        HPText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        HPText.text = "HP : " + player.hp + " / " + player.hpmax;


    }
}
