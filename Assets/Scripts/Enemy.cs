using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float leftBound, rightBound;

    private Rigidbody2D rb2d;

    public float speed = 3f;

	// Use this for initialization
	void Start ()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);

        if (transform.position.x < leftBound || transform.position.x > rightBound)
            speed *= -1;

        if (transform.position.x < leftBound && speed < 0)
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
        else if(transform.position.x > rightBound && speed > 0)
            transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);

        if (speed > 0 && transform.localScale.x == -1)
            transform.localScale = new Vector3(1, 1, 1);
        else if (speed < 0 && transform.localScale.x == 1)
            transform.localScale = new Vector3(-1, 1, 1);

        Debug.Log("Speed: " + speed);
    }

    void FixedUpdate()
    {
        //rb2d.position = new Vector3(rb2d.position.x + speed, transform.position.y, transform.position.z);
    }

    public void SetLeftBound()
    {
        leftBound = gameObject.transform.position.x;
    }

    public void SetRightBound()
    {
        rightBound = gameObject.transform.position.x;
    }
}
