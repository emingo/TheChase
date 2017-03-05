using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour {

    public Text gameOverText;
    public int score = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameOverText.text = score + "";
		
	}

    public void ReloadLevel()
    {
        
        Application.LoadLevel(Application.loadedLevel);
    }
}
