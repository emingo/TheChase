using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Runner {

    public int damage = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	new void Update () {
        base.Update();
	}

    IEnumerator HitCoroutine(Player player)
    {

        yield return new WaitForSeconds(.3f);
        player.hp -= damage;
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(HitCoroutine(collision.gameObject.GetComponent<Player>()));
        }
    }
}
