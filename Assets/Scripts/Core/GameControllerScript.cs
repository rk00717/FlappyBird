
/*
    ##################################################################################################################
        This script will responsible for the score management and to check if the bird is died or not if died 
                   then the game will end and switch the screen between main lobby to game scene
    ##################################################################################################################
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameControllerScript : MonoBehaviour{
    public int scorePoints = 0;

    public bool isFinished = false;

    [SerializeField]
    private TextMeshProUGUI board;

    void Update(){
        if(isFinished){            
            isFinished = false;
            
            EndGame();
        }

        board.text = "Score : " + scorePoints;
    }

    void EndGame(){
        SaveSystem.SaveScore(this);
        SceneManager.LoadScene("LobbyScene");
    }
}