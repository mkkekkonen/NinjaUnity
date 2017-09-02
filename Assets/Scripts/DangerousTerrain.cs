using UnityEngine;
using System.Collections;

public class DangerousTerrain : MonoBehaviour {

    private Player player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            player.HealthBar.value = 0;
    }
}
