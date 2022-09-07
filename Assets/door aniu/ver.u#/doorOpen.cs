
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common;

public class doorOpen : UdonSharpBehaviour
{
    public Animator door;
    public Transform Z;
    bool isClose = true;
    void Start()
    {
    }
    public override void Interact()
    {
        if (isClose)
        {
            if (Z.rotation.z >= -1)
            {
                door.Play("open");
                isClose = !isClose;
            }
        }
        else
        {
            door.Play("close");
            isClose = !isClose;
        }
    }
}
