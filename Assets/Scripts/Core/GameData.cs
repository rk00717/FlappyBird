/*
    ##################################################################################################################
            This script will hold the data which we wanted to save and load to and from the game itself.
                      In our case its the HighScore that we want too save and load for now.
    ##################################################################################################################
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData{
    public int Score;

    public GameData(GameControllerScript gameData){
        Score = gameData.scorePoints;
    }
}