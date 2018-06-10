using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    //public vars
    public GameObject mainMenuPanel;
    public GameObject newGamePanel;

    public GameObject decreasePlayersButton;
    public GameObject increasePlayersButton;

    public GameObject decreasePointsButton;
    public GameObject increasePointsButton;

    public Text playerCountText;
    public Text pointsText;

    //private vars
    private int playerCount;
    private int pointsToWin;

    private int minPlayers = 2;
    private int maxPlayers = 4;

    private int minPoints = 5;
    private int maxPoints = 30;

	// Use this for initialization
	void Start () {
        mainMenuPanel.SetActive(true);
        newGamePanel.SetActive(false);

        playerCount = 2;
        pointsToWin = 5;
    }
	
	// Update is called once per frame
	void Update () {
		//Disable/enable arrow buttons

        if (playerCount == minPlayers)
        {
            decreasePlayersButton.SetActive(false);
        }
        else
        {
            decreasePlayersButton.SetActive(true);
        }

        if (playerCount == maxPlayers)
        {
            increasePlayersButton.SetActive(false);
        }
        else
        {
            increasePlayersButton.SetActive(true);
        }

        if (pointsToWin == minPoints)
        {
            decreasePointsButton.SetActive(false);
        }
        else
        {
            decreasePointsButton.SetActive(true);
        }

        if (pointsToWin == maxPoints)
        {
            increasePointsButton.SetActive(false);
        }
        else
        {
            increasePointsButton.SetActive(true);
        }
    }

    //Button events
    public void newGame()
    {
        mainMenuPanel.SetActive(false);
        newGamePanel.SetActive(true);
    }

    public void exit()
    {
        Application.Quit();
    }

    public void back()
    {
        mainMenuPanel.SetActive(true);
        newGamePanel.SetActive(false);
    }

    public void increasePlayers()
    {
        playerCount = playerCount + 1;
        playerCountText.text = playerCount.ToString();
    }

    public void decreasePlayers()
    {
        playerCount = playerCount - 1;
        playerCountText.text = playerCount.ToString();
    }

    public void increasePoints()
    {
        pointsToWin = pointsToWin + 5;
        pointsText.text = pointsToWin.ToString();
    }

    public void decreasePoints()
    {
        pointsToWin = pointsToWin - 5;
        pointsText.text = pointsToWin.ToString();
    }
}
