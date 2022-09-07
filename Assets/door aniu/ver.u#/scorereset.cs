
using TMPro;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Wrapper.Modules;

public class scorereset : UdonSharpBehaviour
{
    public TextMeshProUGUI Left, Right;
    public GameObject LeftCube, RightCube;
    public override void Interact()
    {
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "resetScore");
    }
    public void resetScore() {
        Left.text = "0";
        Right.text = "0";
        this.gameObject.SetActive(false);
        SendCustomEventDelayedSeconds("ON", 1);
    }
    public void ON()
    {
        this.gameObject.SetActive(true);
    }
    private void FixedUpdate()
    {
        bool LeftOn, RightOn;
        LeftOn = LeftCube.activeInHierarchy;
        RightOn = RightCube.activeInHierarchy;
        if(!LeftOn && !RightOn)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }

}
