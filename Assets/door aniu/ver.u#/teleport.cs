
using TMPro;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;

public class teleport : UdonSharpBehaviour
{
    public Rigidbody balls_rigid;
    public VRCObjectSync ball;
    public TextMeshProUGUI LeftPlayer, RightPlayer;
    //public TextMeshProUGUI Left, Right;
    //public TextMeshProUGUI[] ReadyText = new TextMeshProUGUI[2];
    //public Transform[] Spawn = new Transform[2];
    public AudioSource Hit;
    public GameObject[] teleportCube = new GameObject[2];
    public GameObject[] scoreCube = new GameObject[2];
    private VRCPlayerApi HitPerson;
    private bool IsGround = false;
    //int scoreleft = 0, scoreright = 0;
    void Start()
    {
    }
    public override void OnPickup()
    {
        if (Networking.GetOwner(this.gameObject) != Networking.LocalPlayer)
        {
            Networking.SetOwner(Networking.LocalPlayer, this.gameObject);
        }
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "ChangeGround");
    }
    public void ChangeGround()
    {
        IsGround = false;
        Debug.Log("pickup");
    }
    private void FixedUpdate()
    {
       // bool IsReady = ReadyText[0].gameObject.activeInHierarchy && ReadyText[1].gameObject.activeInHierarchy;
        
        float ballX = this.transform.position.x;
        float ballY = this.transform.position.y;
        float ballZ = this.transform.position.z;
        if (!IsGround)
        {
            if (this.gameObject.transform.position.y <= -0.55)
            {
                IsGround = true;
                Debug.Log("IsGround");
            }
        }
        if ((ballX < -27.63 || ballX > -12.38)|| (ballZ < -11.88 || ballZ > 12.45))
        {
            ball.Respawn();
        }
        /*if (!IsReady)
        {
            scoreleft = 0; scoreright = 0;
        }*/
    }
    public override void OnPlayerCollisionEnter(VRCPlayerApi player)
    {
        HitPerson = player;
        float playerX = HitPerson.GetPosition().x;
        float playerZ = HitPerson.GetPosition().z;
        if ((playerX <= -12.38 && playerX >= -27.63) && (playerZ <= 12.06 && playerZ >= 0.37)&& !IsGround)
        {
            if (!(HitPerson.IsOwner(this.gameObject)))
            {
                SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "AddNumLeft");
                Hit.Play();
                Networking.SetOwner(HitPerson, this.gameObject);
               // Networking.SetOwner(HitPerson, teleportCube[1]);
                SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.Owner, "teleportRight");
            }
        }
        if ((playerX <= -12.38 && playerX >= -27.63) && (playerZ <= 0.37 && playerZ >= -12.17))
        {
            if (!(HitPerson.IsOwner(this.gameObject)))
            {
                SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "AddNumRight");
                Hit.Play();
                Networking.SetOwner(HitPerson, this.gameObject);
               // Networking.SetOwner(HitPerson, teleportCube[0]);
                SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.Owner, "teleportLeft");
            }
        }
    }
    public void teleportLeft()
    {
        teleportCube[0].SetActive(true);
    }
    public void teleportRight()
    {
        teleportCube[1].SetActive(true);
    }
    /*public void AddNumLeft()
    {
        scoreleft++;
        Left.text = scoreleft.ToString();
    }
    public void AddNumRight()
    {
        scoreright++;
        Right.text = scoreright.ToString();
    }*/
    public void AddNumLeft()
    {
        scoreCube[0].SetActive(true);
    }
    public void AddNumRight()
    {
        scoreCube[1].SetActive(true);
    }
}
