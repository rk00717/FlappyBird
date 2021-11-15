/*
    ##################################################################################################################
            This script is the heart of the game. basically it will control entire movement of the game
                e.g. The background, the ground, the score point and the pipe itself as configured 
    ##################################################################################################################
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScroll : MonoBehaviour{
    private GameObject currentObject;
    private Rigidbody2D currentObjectbody;
    private Transform currentObjectPos;

    [SerializeField]
    private GameObject imagePrefab;
    private Vector3 imagePosition;

    private List<GameObject> prefabs = new List<GameObject>();

    [SerializeField]
    private int invisOffset = -20;
    [SerializeField]
    private float spwanOffset = 17.9f;
    private float temp_spwanOffset;
    [SerializeField]
    private int maxLimit = 3;

    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float minSpeed = 0;
    [SerializeField]
    private float maxSpeed;

    [SerializeField]
    private float coolDown = 20;
    private float nextTime;

    [SerializeField]
    private bool scrollable = false;
    
    [SerializeField]
    private int points = 1;

    void Start(){
        temp_spwanOffset = spwanOffset;
        for(int i = 0; i < maxLimit; i++) SpwanObject(spwanOffset*i);

        nextTime = Time.time + coolDown;
    }

    void LateUpdate(){
        for(int i=0; i<prefabs.Count; i++){
            currentObject = prefabs[i];

            currentObjectPos = currentObject.GetComponent<Transform>();
            currentObjectbody = currentObject.GetComponent<Rigidbody2D>();
            
            // currentObjectbody.velocity = Vector3.left;
            currentObjectbody.velocity = new Vector3(-moveSpeed, 0f);

            if(currentObjectPos.position.x <= invisOffset){
                if(scrollable){
                    currentObjectPos.Translate(new Vector3(transform.position.x + spwanOffset*prefabs.Count, transform.position.y, transform.position.z));
                    prefabs.RemoveAt(i);
                    prefabs.Add(currentObject);
                }else{
                    Destroy(currentObjectPos.gameObject);
                    prefabs.RemoveAt(i);
                    if(transform.childCount < maxLimit){
                        SpwanObject(spwanOffset + prefabs.Count);
                    }
                }
            }
        }

        if(Time.time > nextTime){
            IncreaseSpeed();
        }
    }

    void SpwanObject(float offset = 0f){
        imagePosition = new Vector3(transform.position.x + offset, imagePrefab.GetComponent<Transform>().position.y, transform.position.z);
        prefabs.Add(Instantiate(imagePrefab, imagePosition, Quaternion.identity, this.transform));
    }

    void IncreaseSpeed(){
        int value = Random.Range(0,100)/10;
        if(value > 8){
            if(!scrollable){
                if(spwanOffset >= 50){
                    spwanOffset = temp_spwanOffset;
                }else{
                    spwanOffset += value;
                }
            }
            moveSpeed += Mathf.Clamp(1, minSpeed, maxSpeed);
        }

        nextTime = Time.time + coolDown;
    }
}
