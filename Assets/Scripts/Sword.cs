using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

    GameState gameState;

	// Use this for initialization
	void Start () {

        gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
            gameState.Points += 50;
        }
    }
}
