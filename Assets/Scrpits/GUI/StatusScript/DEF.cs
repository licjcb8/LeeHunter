using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DEF : MonoBehaviour
{
    public Player player;

    public Text DEFText;
    // Use this for initialization
    void Start()
    {
        DEFText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        DEFText.text = "DEF : " + player.def;
    }
}
