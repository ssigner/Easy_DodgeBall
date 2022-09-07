
using TMPro;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ballplusenable : UdonSharpBehaviour
{
    public GameObject plusCube;
    public GameObject minusCube;
    bool OnOff = false;
    public TextMeshProUGUI plusMode;
    void Start()
    {
    }
    public override void Interact()
    {
        if (OnOff)
        {
            SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "MinusOn");
            OnOff = !OnOff;
        }
        else
        {
            SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "PlusOn");
            OnOff = !OnOff;
        }
    }
    public void PlusOn()
    {
        plusMode.gameObject.SetActive(true);
    }
    public void MinusOn()
    {
        plusMode.gameObject.SetActive(false);
    }

}
