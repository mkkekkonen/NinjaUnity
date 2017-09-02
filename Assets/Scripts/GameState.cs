using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameState : MonoBehaviour {

    public Text pointsText;

    public int Points { get; set; }
    public bool Won { get; set; }

	// Use this for initialization
	void Start () {

        Points = 0;
        Won = false;
	}
	
	// Update is called once per frame
	void Update () {

        if(pointsText != null)
            pointsText.text = "Points: " + Points;
	}
}
