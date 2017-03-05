using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected void Update () {
        transform.Rotate(Vector3.up * 270 * Time.deltaTime, Space.World);
		
	}

    protected virtual void PickupAction(GameObject other)
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        PickupAction(other.gameObject);
    }
}
