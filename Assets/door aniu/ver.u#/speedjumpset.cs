
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class speedjumpset : UdonSharpBehaviour
{
    void Start()
    {
        
    }
    public override void OnPlayerJoined(VRCPlayerApi player)
    {
        player.SetWalkSpeed(3);
        player.SetRunSpeed(5);
        player.SetJumpImpulse(4.5f);
    }
}
