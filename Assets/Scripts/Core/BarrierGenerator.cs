/*
    ##################################################################################################################
                    This will generate random location to spwan the pipes and make a gap for the 
                                bird to pass through it at random places in th game.
    ##################################################################################################################
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierGenerator : MonoBehaviour{
    [SerializeField]
    private GameObject topPipe;
    [SerializeField]
    private GameObject bottomPipe;
    [SerializeField]
    private GameObject scorePoint;
    [SerializeField]
    private GameObject normalScorePoint;

    [SerializeField]
    private float minGapOffset;
    [SerializeField]
    private float maxGapOffset;
    [SerializeField]
    private float gapOffset;
    [SerializeField]
    private float maxHeight;
    [SerializeField]
    private float minHeight;
    [SerializeField]
    private Vector3 spawnPos;

    void Start(){
        spawnPos = transform.position;
        spawnPos.y = GenerateValue(minHeight, maxHeight)-5;
        gapOffset = GenerateValue(minGapOffset, maxGapOffset);
        SpawnBarrier();
        PlacePoints();
    }

    float GenerateValue(float minV, float maxV){
        return Random.Range(minV, maxV);
    }

    void SpawnBarrier(){
        GameObject bottomPrefab = Instantiate(bottomPipe, spawnPos, Quaternion.identity, this.transform);
        spawnPos.y += gapOffset + 10f;
        GameObject topPrefab = Instantiate(topPipe, spawnPos, Quaternion.identity, this.transform);
    }

    void PlacePoints(){
        int value = Random.Range(0,100);
        if(value > 89){
            spawnPos.y -= 5f + (gapOffset/2);
            Instantiate(scorePoint, spawnPos, Quaternion.identity, this.transform);
        }else{
            spawnPos.y = 0;
            Instantiate(normalScorePoint, spawnPos, Quaternion.identity, this.transform);
        }
    }
}