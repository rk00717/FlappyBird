using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCoin : MonoBehaviour{
    [SerializeField]
    private int points = 50;

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            GameObject.FindWithTag("GameController").GetComponent<GameControllerScript>().scorePoints += points;
            Destroy(gameObject);
        }
    }
}