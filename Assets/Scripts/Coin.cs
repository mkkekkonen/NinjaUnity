using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    GameState gameState;

	// Use this for initialization
	void Start () {

        gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            gameState.Points += 10;
            Destroy(gameObject);
        }
    }
}
