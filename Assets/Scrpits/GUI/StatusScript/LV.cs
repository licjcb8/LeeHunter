using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LV : MonoBehaviour
{
    public Player player;

    public Text LVText;

    // Use this for initialization
    void Start()
    {
        LVText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        LVText.text = "LV : " + player.lv;


    }
}
