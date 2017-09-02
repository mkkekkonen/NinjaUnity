using UnityEngine;
using System.Collections;

public class CameraBounds : MonoBehaviour {

    public float minX, minY, maxX, maxY;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(
            player.transform.position.x,
            player.transform.position.y,
            transform.position.z
        );

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY),
            transform.position.z
        );
    }

    public void SetMinPos()
    {
        minX = transform.position.x;
        minY = transform.position.y;
    }

    public void SetMaxPos()
    {
        maxX = transform.position.x;
        maxY = transform.position.y;
    }
}
