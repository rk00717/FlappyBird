/*
    ##################################################################################################################
        This Script will manage the movement of bird and checsks if the bird is collided with the pipes or not if 
                    yes then it will send signal to the game controller script to end the game.
                And also increase the points by 1 if the bird passes through the pipes successfully
    ##################################################################################################################
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour{
    private Rigidbody2D body;
    private Animator animator;

    [SerializeField]
    private AudioClip flySound;

    [SerializeField]
    private float jumpHeight = 5f;

    [SerializeField]
    private float coolDown;
    private float nextTime;

    void Start(){
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        nextTime = Time.time + coolDown;
    }

    void Update(){
        if(Input.GetButtonDown("Jump")){
            animator.SetBool("flap_bird", true);
            SoundManager.instance.PlaySound(flySound);
            body.velocity = new Vector2(0, jumpHeight);
            nextTime = Time.time + coolDown;
        }

        if(Time.time > nextTime){
            animator.SetBool("flap_bird", false);
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
