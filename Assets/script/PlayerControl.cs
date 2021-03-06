﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

void OnTriggerEnter2D(Collider2D other){
    if (other.gameObject.CompareTag("Coin")){
        SFXManager.instance.ShowCoinParticles(other.gameObject);
       AudioManager.instance.PlaySoundCoinPickup(other.gameObject);
        Destroy(other.gameObject);
        CineManager.instance.IncrementCoinCount();
    }
    if (other.gameObject.CompareTag("Gift")){

       AudioManager.instance.PlaySoundlevelComplete(gameObject);
        StopMusicAndTape();
    
         Destroy(other.gameObject);
   
         CineManager.instance.ShowLevelCompletePanel();

    }
else if (other.gameObject.layer == LayerMask.NameToLayer("Enemies")){
    KillPlayer();
}

else if (other.gameObject.layer == LayerMask.NameToLayer("forbiden")){
KillPlayer();
}

}


void StopMusicAndTape (){
     Camera.main.GetComponentInChildren<AudioSource>().mute = true;
    CineManager.instance.SetTapeSpeed(0);
}

void KillPlayer(){
     StopMusicAndTape();
    AudioManager.instance.PlaySoundFail(gameObject);
    SFXManager.instance.ShowDieParticles(gameObject);
    Destroy(gameObject);

    CineManager.instance.ShowGameOverPanel();
}


}
