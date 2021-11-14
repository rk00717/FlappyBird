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