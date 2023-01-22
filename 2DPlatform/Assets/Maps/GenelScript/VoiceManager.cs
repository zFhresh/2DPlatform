using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceManager : MonoBehaviour
{
    [SerializeField]AudioSource Source;
    [SerializeField] AudioClip[] Clips;
    void Start()
    {
        Source = GetComponent<AudioSource>();
    }
    List<AudioClip> WaitingClips = new List<AudioClip>();
    public void PlayASound(int index,bool AddWaitingList) {
        if(!Source.isPlaying) {
            Source.clip = Clips[index];
            Source.loop = false;
             Source.Play();
        }
        else if(AddWaitingList) {
            WaitingClips.Add(Clips[index]);
        }
    }   
    public void StopSound() {
        Source.Stop();
    }
    public void PlayASoundLoop(int index) {
        if(!Source.isPlaying) {
            Source.clip = Clips[index];
            Source.loop = true;
             Source.Play();
        }
    }
}
