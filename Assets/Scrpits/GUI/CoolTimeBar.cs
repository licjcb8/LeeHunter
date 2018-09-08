using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoolTimeBar : MonoBehaviour {
    public Player player;
    public Slider CooltimeBar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CooltimeBar.value = (float)player.accumulator / 1.0f;
	}
}
