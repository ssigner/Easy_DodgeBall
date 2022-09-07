
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class teleportperson : UdonSharpBehaviour
{
    public Transform teleport;
    void Start()
    {
    }
    public void OnEnable()
    {
        Networking.LocalPlayer.TeleportTo(teleport.position, teleport.rotation);
        this.gameObject.SetActive(false);
    }

}
