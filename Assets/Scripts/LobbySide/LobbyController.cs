/*
    ##################################################################################################################
                    This will switch from lobby scene to game scene when user play jump button
    ##################################################################################################################
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour{
    void Update(){
        if(Input.GetButtonDown("Jump")){
            SceneManager.LoadScene("GameScene");
        }
    }
}