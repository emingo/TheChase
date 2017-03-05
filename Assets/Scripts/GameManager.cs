using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    [Header("Game Variables")]
    public float gameTime = 30;
    public int lives = 5;
    public int enemyDamage = 1;
    public float characterSpeed = 8;


    [Space(50)]
    public Transform player;
    public Transform roadPiece;
    public Transform speedBooster;


    public Transform gameUI;
    public Transform gameOverUI;
    public TimeUI timeUI;

    Vector3 pos;
    Vector3 lastRoadPos;
    Transform lastRoad;
    // Use this for initialization

    

    bool gameOver = false;

    void Awake()
    {
        lastRoad = Instantiate(roadPiece, transform.position, Quaternion.identity);
        lastRoadPos = lastRoad.position;

        
        for (int i = 0; i < 5; i++)
        {
            pos = lastRoadPos;
            pos.z += 40;
            lastRoad = Instantiate(roadPiece, pos, Quaternion.identity);
            lastRoadPos = lastRoad.position;
            spawnBoosters(lastRoadPos.z);
        }

        player.GetComponent<Player>().hp = lives;
        player.GetComponent<Player>().runSpeed = characterSpeed;


    }
    void Start () {


	}
	
	// Update is called once per frame
	void Update () {

        if (gameOver)
        {
            return;
        }

        
        
        if(gameTime > 0)
        {
            gameTime -= Time.deltaTime;
            timeUI.time = gameTime;
        }
        else
        {
            gameTime = 0;
            player.GetComponent<Player>().GameOver();
            gameUI.gameObject.SetActive(false);
            gameOverUI.gameObject.SetActive(true);
            gameOverUI.GetComponent<GameOverUI>().score = player.GetComponent<Player>().score;
            gameOver = true;
        }

        if (player.position.z + 200 > lastRoadPos.z)
        {
            pos = lastRoadPos;
            pos.z += 40;
            lastRoad = Instantiate(roadPiece, pos, Quaternion.identity);
            lastRoadPos = lastRoad.position;
            spawnBoosters(lastRoadPos.z);
        }

        if(player.GetComponent<Player>().hp <= 0)
        {
            gameUI.gameObject.SetActive(false);
            gameOverUI.gameObject.SetActive(true);
            gameOverUI.GetComponent<GameOverUI>().score = player.GetComponent<Player>().score;
            gameOver = true;
        }
		
	}

    void spawnBoosters(float startZ)
    {
        float currentZ = startZ;

        Vector3 spawnPos;
        while(currentZ < startZ + 40)
        {
            currentZ += Random.Range(4f, 12f);
            spawnPos = new Vector3(Random.Range(-3f, 3f), .5f, currentZ);

            Instantiate(speedBooster, spawnPos, speedBooster.rotation).Rotate(Vector3.up * Random.Range(0, 360), Space.World);
        }

    }


}
