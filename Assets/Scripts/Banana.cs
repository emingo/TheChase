using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Pickup {

    public int damage = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	new void Update () {
        base.Update();
	}

    protected override void PickupAction(GameObject other)
    {
        if (other.tag == "Player")
        {
            print(other.name);
            other.GetComponent<Player>().hp-=damage;
            other.GetComponent<Player>().SpeedBoost(-3, 2);
            base.PickupAction(other);
        }
    }
}
