
using UdonSharp;
using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;

public class music : UdonSharpBehaviour
{   
    public AudioSource emerald;
    bool isPlaying = false;
    void Start()
    {
    }
    public override void Interact()
    {
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "PlayMusic");
    }
    public void PlayMusic()
    {
        if (isPlaying)
        {
            emerald.Pause();
            isPlaying = !isPlaying;
        }
        else
        {
            emerald.Play();
            isPlaying = !isPlaying;
        }
    }
}
