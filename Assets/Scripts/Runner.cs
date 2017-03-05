using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour {


    public float runSpeed;
    public float sideSpeed;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected void Update () {
        transform.Translate(transform.forward * Time.deltaTime * runSpeed);
	}

    public void sideMove(float dir){
        transform.Translate(transform.right * dir * sideSpeed * Time.deltaTime);
    }

    public void jump()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * 10, ForceMode.Impulse);
    }


}
