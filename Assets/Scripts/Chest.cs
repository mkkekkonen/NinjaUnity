using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {

    public GameObject uWonPanel;
    public Sprite openSprite;

    private GameState gameState;

	// Use this for initialization
	void Start () {

        gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            gameState.Points += 100;

            if(uWonPanel != null)
            {
                gameState.Won = true;
                uWonPanel.SetActive(true);
                if(openSprite != null)
                    gameObject.GetComponent<SpriteRenderer>().sprite = openSprite;
                Time.timeScale = 0;
            }
        }
    }
}
