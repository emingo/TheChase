using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : Enemy {

    public Transform spawnPoint;
    public Transform enemy;
    public Transform banana;

    public GameManager gameManager;


    float[] positions;
    float goal;

    // Use this for initialization
    void Start () {

        positions = new float[] { 3, 0, -3};

        StartCoroutine(TruckMovement());
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnBananas());
		
	}
	
	// Update is called once per frame
	new void Update () {

        base.Update();
	}

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(.4f, 1f));
            enemy.GetComponent<Enemy>().damage = gameManager.enemyDamage;
            Instantiate(enemy, spawnPoint.position, Quaternion.identity);
        }
    }

    IEnumerator SpawnBananas()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));
            banana.GetComponent<Banana>().damage = gameManager.enemyDamage;
            Instantiate(banana, spawnPoint.position, banana.rotation);
        }
    }

    IEnumerator TruckMovement()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(.5f, 1f));
            goal = positions[Random.Range(0, 3)];
            while(Mathf.Abs(transform.position.x - goal) > 0.05)
            {
                sideMove(Mathf.Clamp(goal - transform.position.x, -1, 1));
                yield return new WaitForFixedUpdate();
            }
        }
    }
}
