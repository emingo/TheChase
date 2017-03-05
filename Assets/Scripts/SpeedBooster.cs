using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : Pickup {

    public float boost;
    public float duration;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	new void Update () {
        base.Update();
	}

    protected override void PickupAction(GameObject other)
    {
        if(other.tag == "Player")
        {
            print(other.name);
            other.GetComponent<Player>().SpeedBoost(boost, duration);
            base.PickupAction(other);
        }
    }
}
