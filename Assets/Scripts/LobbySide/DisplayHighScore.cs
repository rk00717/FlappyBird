/*
    ##################################################################################################################
                    This will load the highscore and display it on the main screen(lobby scene)
    ##################################################################################################################
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHighScore : MonoBehaviour{
    void Awake(){
        GameData data = SaveSystem.LoadScore();

        TextMeshProUGUI board = GetComponent<TextMeshProUGUI>();
        board.text = "HighScore : " + data.Score;
    }
}