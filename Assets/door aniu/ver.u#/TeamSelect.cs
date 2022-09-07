
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

public class TeamSelect : UdonSharpBehaviour
{
    public TextMeshProUGUI PlayerName;
    public GameObject Walls;
    public Animator[] WallDown = new Animator[2];
    public GameObject[] TeamCube = new GameObject[2];

    void Start()
    {
    }
    public override void Interact()
    {
        bool check = true;
        if (Networking.GetOwner(this.gameObject) != Networking.LocalPlayer)
        {
            Networking.SetOwner(Networking.LocalPlayer, this.gameObject);
        }
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "ChangeName");
        for(int i = 0; i < TeamCube.Length; i++)
        {
            if (TeamCube[i].activeInHierarchy)
            {
                check = false;
            }
        }
        if ((this.gameObject.name == "team right"|| this.gameObject.name == "team right1") && check)
        {
            SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "RightWallsDown");
        } else if((this.gameObject.name == "team left" || this.gameObject.name == "team left1") && check)
        {
            SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "LeftWallsDown");
        }
    }
    public void ChangeName()
    {
        VRCPlayerApi clickPerson = Networking.GetOwner(this.gameObject);
        string myName = clickPerson.displayName;
        PlayerName.text = myName;
        this.gameObject.SetActive(false);
    }
    public void LeftWallsDown()
    {
        Walls.SetActive(true);
        WallDown[0].Play("LeftWall");
    }
    public void RightWallsDown()
    {
        Walls.SetActive(true);
        WallDown[1].Play("RightWall");
    }
}
