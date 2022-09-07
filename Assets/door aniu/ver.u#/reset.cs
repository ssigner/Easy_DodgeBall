
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.SDK3.Components;

public class reset : UdonSharpBehaviour
{
    public VRCObjectSync[] balls = new VRCObjectSync[4];
    void Start()
    {    
    }
    public override void Interact()
    {
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "respawn");
    }
    public void respawn()
    {
        for(int i = 0; i < balls.Length; i++)
        {
            if (Networking.IsOwner(balls[i].gameObject))
            {
                balls[i].Respawn();
            }
        }
    }
}
