
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

public class Ready : UdonSharpBehaviour
{
    public TextMeshProUGUI NowReady;
    void Start()
    {
        
    }
    public override void Interact()
    {
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "CubeOut");
    }
    public void CubeOut()
    {
        this.gameObject.SetActive(false);
        NowReady.gameObject.SetActive(true);
    }
}
