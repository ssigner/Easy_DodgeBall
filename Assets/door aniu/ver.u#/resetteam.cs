
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

public class resetteam : UdonSharpBehaviour
{
    public GameObject[] LeftCube = new GameObject[2];
    public GameObject[] RightCube = new GameObject[2];
    public TextMeshProUGUI[] LeftTeam = new TextMeshProUGUI[2];
    public TextMeshProUGUI[] RightTeam = new TextMeshProUGUI[2];
    public TextMeshProUGUI LeftScore, RightScore;
    void Start()
    {
        
    }
    public override void Interact()
    {
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "TeamReset");
    }
    public void TeamReset()
    {
        for(int i = 0; i < LeftCube.Length; i++) LeftCube[i].SetActive(true);
        for(int i = 0; i < RightCube.Length; i++) RightCube[i].SetActive(true);
        for (int i = 0; i < LeftTeam.Length; i++) LeftTeam[i].text = "player1";
        for (int i = 0; i < RightTeam.Length; i++) RightTeam[i].text = "player2";
        LeftScore.text = "0";
        RightScore.text = "0";
    }
}
