
using UdonSharp;
using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;

public class tadaNoPlay : UdonSharpBehaviour
{
    public VRCObjectSync ball;
    void Start()
    {

    }
    public void FixedUpdate()
    { 
        float thisX = this.transform.position.x;
        float thisY = this.transform.position.y;
        float thisZ = this.transform.position.z;
        if ((thisX > 10 || thisX < -10) || (thisY > 10) || (thisZ > 2.45 || thisZ < -7.4))
        {
            ball.Respawn();
        }
            
    }
}
