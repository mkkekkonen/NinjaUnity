using UnityEngine;
using System.Collections;

public class EnemyCheck : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            GetComponentInParent<Player>().GetHurt();
        }
    }
}
