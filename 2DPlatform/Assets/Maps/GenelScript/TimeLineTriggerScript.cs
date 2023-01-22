using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class TimeLineTriggerScript : MonoBehaviour
{
    PlayableDirector Director;
    bool isEnd = false;
    void Start()
    {
        Director = GetComponent<PlayableDirector>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(!isEnd) {
            Director.Play();
            isEnd = true;
        }
      
    }
}
