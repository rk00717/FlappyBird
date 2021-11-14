using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour{
    private Rigidbody2D body;

    [SerializeField]
    private float jumpHeight = 5f;

    void Start(){
        body = GetComponent<Rigidbody2D>();
    }

    void Update(){
        if(Input.GetButtonDown("Jump")){
            body.velocity = new Vector2(0, jumpHeight);
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Finish"){
            GameObject.FindWithTag("GameController").GetComponent<GameControllerScript>().isFinished = true;
        }
        if(collision.gameObject.tag == "NormalCoin"){
            GameObject.FindWithTag("GameController").GetComponent<GameControllerScript>().scorePoints ++;
        }
    }
}
