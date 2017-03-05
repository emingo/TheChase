using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Runner {
    public int score = 0;

    public int hp = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	new void Update () {
        base.Update();

        if(hp <= 0)
        {
            GameOver();
        }
	}

    public void GameOver()
    {
        GetComponent<Animator>().SetTrigger("Die");
        Destroy(GetComponent<CharacterInput>());
        Destroy(GetComponent<Rigidbody>());
        Destroy(this);
    }

    public void SpeedBoost(float boost, float sec)
    {
        score += 100;
        //StartCoroutine();
        StartCoroutine(SpeedBoostCoroutine(boost, sec));

    }
    IEnumerator SpeedBoostCoroutine(float boost, float sec)
    {
        runSpeed += boost;
        sideSpeed += boost;
        yield return new WaitForSeconds(sec);
        runSpeed -= boost;
        sideSpeed -= boost;
        yield break;
    }
}
