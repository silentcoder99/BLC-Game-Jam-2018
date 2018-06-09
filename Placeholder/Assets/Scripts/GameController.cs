using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    //Public vars
    public int playerCount;
    public Rigidbody2D playerPrefab;

    //Private vars
    private int[] scores;
    private GameObject[] players;
    private float spawnXRange = 5;

	// Use this for initialization
	void Start () {
        scores = new int[playerCount];
        players = new GameObject[playerCount];

        reset();
    }
	
	// Update is called once per frame
	void Update () {
        //Count players
        int alivePlayerCount = 0;

        foreach (GameObject player in players)
        {
            if (player.scene.isValid())
            {
                alivePlayerCount++;
            }
        }

        //If 1 player is left, give them a point
        if (alivePlayerCount == 1)
        {
            
        }
	}

    void reset()
    {
        //Instantiate players
        float playerSpacing = (spawnXRange * 2) / (playerCount - 1);
        for (int i = 0; i < playerCount; i++)
        {
            float playerX = (float) i * playerSpacing - spawnXRange;
            players[i] = Instantiate(playerPrefab, new Vector3(playerX, 0, 0), transform.rotation).gameObject;
        }
    }
}
