using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VarHolder {

    public static int playerCount = 4;
    public static int pointsToWin = 5;

    public static int[] scores;

    public static void initScores()
    {
        scores = new int[playerCount];

        for(int i = 0; i < playerCount; i++)
        {
            scores[i] = 0;
        }
    }
}
