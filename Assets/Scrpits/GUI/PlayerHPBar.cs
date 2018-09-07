using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour {
    public Player player;
    public Slider hpBar;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        hpBar.value = (float)player.hp / (float)player.hpmax;
	}
}
