using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

struct PlayerStat
{
    public GameObject gameObject;
    public int score;
    public GameObject scoreUI;
}

public class GameController : MonoBehaviour {
    //Public vars
    public int playerCount;
    public Rigidbody2D playerPrefab;
    public GameObject scorePrefab;
    public string[] playerKeys;
    public Color[] colours;
    public int pointsToWin = 5;

    //Private vars
    private PlayerStat[] players;
    private float spawnXRange = 5;
    private float scoreXRange = 780;
    private float scoreY =  420;
    private GameObject canvas;
    private GameObject canvas_Scores;
    private GameObject canvas_Prompts;

    // Use this for initialization
    void Start () {
        playerCount = VarHolder.playerCount;
        pointsToWin = VarHolder.pointsToWin;

        players = new PlayerStat[playerCount];
        canvas_Scores = GameObject.Find("Can_Scores");
        canvas_Prompts = GameObject.Find("Can_Controls");
        init();
    }

    // Update is called once per frame
    void Update()
    {
        //Count players
        int alivePlayerCount = GameObject.FindGameObjectsWithTag("Player").Length;

        //If 1 player's left, give them a point and reset
        if (alivePlayerCount == 1)
        {
            int winner = 0;

            for (int i = 0; i < playerCount; i++)
            {
                if (players[i].gameObject)
                {
                    winner = i;
                    break;
                }
            }

            players[winner].score = players[winner].score + 1;

            //Set score
            Text textComponent = players[winner].scoreUI.GetComponent<Text>();
            textComponent.text = players[winner].score.ToString();

            //Kill last player before respawn
            GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");

            foreach (GameObject playerObject in playerObjects)
            {
                Destroy(playerObject);
            }

            respawn();


        }
    }

    void init()
    {
        //Instantiate scoring and players
        float scoreSpacing = (scoreXRange * 2) / (playerCount - 1);
        for (int i = 0; i < playerCount; i++)
        {
            float scoreX = (float) i * scoreSpacing - scoreXRange;
            players[i].scoreUI = Instantiate(scorePrefab, new Vector3(scoreX, scoreY, 0), transform.rotation);
            players[i].scoreUI.GetComponent<Text>().color = colours[i];
            players[i].scoreUI.transform.SetParent(canvas.transform);
            players[i].scoreUI.transform.localPosition = new Vector3(scoreX, scoreY, 0);
            players[i].score = 0;
        }

        respawn();
    }

    void respawn()
    {
        //Reset players
        float playerSpacing = (spawnXRange * 2) / (playerCount - 1);
        for (int i = 0; i < playerCount; i++)
        {
            //Instantiate player
            float playerX = (float)i * playerSpacing - spawnXRange;
            players[i].gameObject = Instantiate(playerPrefab, new Vector3(playerX, 0, 0), transform.rotation).gameObject;
            //prompt telling player which button to use
            GameObject prompt = Instantiate(promptPrefab, players[i].gameObject.transform.position, transform.rotation).gameObject;
            prompt.transform.SetParent(canvas_Prompts.transform);
            prompt.GetComponent<Text>().text = playerKeys[i];
            prompt.transform.localScale = new Vector3(1, 1, 1);
            //TODO: do this better
            Vector3 temp = prompt.transform.localPosition;
            temp.y = -80;
            prompt.transform.localPosition = temp;

            //Set fire key
            PlayerController script = players[i].gameObject.GetComponent<PlayerController>();
            script.key = playerKeys[i];
            script.colour = colours[i];
            script.prompt = prompt;
        }
    }
}
