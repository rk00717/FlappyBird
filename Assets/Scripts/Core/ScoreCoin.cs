/*
    ##################################################################################################################
        This script will be attached to the coin itself whenever it get hit by the bird it will add the decided 
                                value to the actual player score and destroy itself.
    ##################################################################################################################
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCoin : MonoBehaviour{
    [SerializeField]
    private int points = 50;
    [SerializeField]
    private AudioClip sound;

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            GameObject.FindWithTag("GameController").GetComponent<GameControllerScript>().scorePoints += points;
            SoundManager.instance.PlaySound(sound);
            Destroy(gameObject);
        }
    }
}