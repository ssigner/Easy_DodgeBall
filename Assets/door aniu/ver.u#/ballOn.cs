
using TMPro;
using UdonSharp;
using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;

public class ballOn : UdonSharpBehaviour
{
    public GameObject[] LeftCube = new GameObject[2];
    public GameObject[] RightCube = new GameObject[2];
    public GameObject[] ReadyCube = new GameObject[2];
    public VRCObjectSync[] Balls = new VRCObjectSync[4];
    public TextMeshProUGUI plustext;
    public VRCObjectSync[] PlusBall = new VRCObjectSync[2];
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        bool LeftOn, RightOn;
        LeftOn = !LeftCube[0].activeInHierarchy && !LeftCube[1].activeInHierarchy;
        RightOn = !RightCube[0].activeInHierarchy && !RightCube[1].activeInHierarchy;
        bool IsReady = !ReadyCube[0].activeInHierarchy && !ReadyCube[1].activeInHierarchy;
        if (LeftOn && RightOn)
        {
            if (IsReady)
            {
                for (int i = 0; i < Balls.Length; i++)
                {
                    Balls[i].gameObject.SetActive(true);
                }
                if (plustext.gameObject.activeInHierarchy)
                {
                    for (int i = 0; i < PlusBall.Length; i++)
                    {
                        PlusBall[i].gameObject.SetActive(true);
                    }
                } else if (!plustext.gameObject.activeInHierarchy)
                {
                    for (int i = 0; i < PlusBall.Length; i++)
                    {
                        PlusBall[i].gameObject.SetActive(false);
                    }
                }
            }
            
        }
        else
        {
            for (int i = 0; i < Balls.Length; i++)
            {
                Balls[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < PlusBall.Length; i++)
            {
                PlusBall[i].gameObject.SetActive(false);
            }
        }
    }
}
