using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Runner))]
public class CharacterInput : MonoBehaviour {

    public Runner runner;

    // Use this for initialization
    void Start () {
        runner = GetComponent<Runner>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if(Input.GetAxisRaw("Horizontal") != 0){
            runner.sideMove(Input.GetAxisRaw("Horizontal"));
        }


        if (Input.GetButtonDown("Jump"))
        {
            //runner.jump();
        }
		
	}

}
