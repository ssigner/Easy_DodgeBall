
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class gotowaiting : UdonSharpBehaviour
{
    public Transform WaitingSpawn;
    void Start()
    {
    }
    public override void Interact()
    {
        VRCPlayerApi Me = Networking.LocalPlayer;
        Me.TeleportTo(WaitingSpawn.position, WaitingSpawn.rotation);
    }
}
