using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXP : MonoBehaviour
{
    public Player player;

    public Text EXPText;

    // Use this for initialization
    void Start()
    {
        EXPText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        EXPText.text = "EXP : " + player.exp + " / " + player.expMax;


    }
}
