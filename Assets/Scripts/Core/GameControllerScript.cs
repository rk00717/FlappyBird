using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameControllerScript : MonoBehaviour{
    public int scorePoints = 0;

    public bool isFinished = false;

    private float nextTime = 0;
    private float coolDown = 5f;

    [SerializeField]
    private TextMeshProUGUI board;

    void Update(){
        if(isFinished && nextTime == 0){
            isFinished = false;

            EndGame();

            nextTime = Time.time+coolDown;
        }
        if(Time.time > nextTime && isFinished){
            isFinished = false;

            EndGame();

            nextTime = Time.time+coolDown;
        }

        board.text = "Score : " + scorePoints;
    }

    void EndGame(){
        SaveSystem.SaveScore(this);
        SceneManager.LoadScene("LobbyScene");
    }
}