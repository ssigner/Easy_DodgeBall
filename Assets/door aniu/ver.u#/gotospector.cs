
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.SDK3.Components;

public class gotospector : UdonSharpBehaviour
{
    public Transform SpectorSpawn;
    void Start()
    {
    }
    public override void Interact()
    {
        VRCPlayerApi Me = Networking.LocalPlayer;
        Me.TeleportTo(SpectorSpawn.position, SpectorSpawn.rotation);
    }
}
