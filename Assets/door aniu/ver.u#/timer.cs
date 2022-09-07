
using TMPro;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;

public class timer : UdonSharpBehaviour
{
    public TextMeshProUGUI time, LeftScoreText, RightScoreText;
    public GameObject[] LeftCube = new GameObject[2];
    public GameObject[] RightCube = new GameObject[2];
    public GameObject[] Walls = new GameObject[2];
    public TextMeshProUGUI[] ReadyText = new TextMeshProUGUI[2];
    public VRCObjectSync[] Balls = new VRCObjectSync[6];
    public GameObject[] AddCube = new GameObject[2];
    public GameObject[] resetCube = new GameObject[2];
    bool LeftOn, RightOn;
    public GameObject TeamResetCube;
    int left=0, right=0;
    [UdonSynced]
    float TotalTime = 120f;
    int minute;
    int second;
    void Start()
    {
    }
    private void Update()
    {
        bool IsReady = ReadyText[0].gameObject.activeInHierarchy && ReadyText[1].gameObject.activeInHierarchy;
        LeftOn = !LeftCube[0].activeInHierarchy && !LeftCube[1].activeInHierarchy;
        RightOn = !RightCube[0].activeInHierarchy && !RightCube[1].activeInHierarchy;
        if (LeftOn && RightOn)
        {
            if (IsReady)
            {
                TeamResetCube.SetActive(false);
                if (TotalTime > 0)
                {
                    if (AddCube[0].activeInHierarchy)
                    {
                        left++;
                    } else if (AddCube[1].activeInHierarchy)
                    {
                        right++;
                    }
                    TotalTime -= Time.deltaTime;
                    minute = (int)(TotalTime / 60);
                    second = (int)(TotalTime % 60);
                    time.text = minute.ToString("00") + ":" + second.ToString("00");
                }
                else
                {
                    for (int j = 0; j < Balls.Length; j++)
                    {
                        Balls[j].Respawn();
                    }
                    TeamResetCube.SetActive(true);
                    for (int i = 0; i < LeftCube.Length; i++) LeftCube[i].SetActive(true);
                    for (int i = 0; i < RightCube.Length; i++) RightCube[i].SetActive(true);
                    Walls[0].SetActive(false);
                    Walls[1].SetActive(false);
                    time.text = "02:00";
                    resetCube[0].SetActive(true);
                    resetCube[1].SetActive(true);
                    for (int j=0; j < AddCube.Length; j++)
                    {
                        AddCube[j].SetActive(true);
                    }
                    for(int i=0; i<ReadyText.Length; i++)
                    {
                        ReadyText[i].gameObject.SetActive(false);
                    }
                    left = 0;
                    right = 0;
                }
            }
            else
            {
                time.text = "02:00";
                TotalTime = 120;
            }
        }
        
        
    }
    public void WinnerSet()
    {
        /*char[] LeftScoreArray = new char[2];
        char[] RightScoreArray = new char[2];
        LeftScoreArray = LeftScoreText.text.ToCharArray();
        RightScoreArray = RightScoreText.text.ToCharArray();
        int Leftscore;
        int Rightscore;
        if (LeftScoreArray.Length > 1)
        {
            Leftscore = (LeftScoreArray[0]-0x30) * 10 + LeftScoreArray[1]-0x30;
        }
        else
        {
            Leftscore = LeftScoreArray[0]-0x30;
        }
        if (RightScoreArray.Length > 1)
        {
            Rightscore = (RightScoreArray[0]-0x30) * 10 + RightScoreArray[1]-0x30;
        }
        else
        {
            Rightscore = RightScoreArray[0]-0x30;
        }*/
        if (left > right)
        {
            LeftScoreText.text = "WIN";
            RightScoreText.text = "LOSE";
        }
        else if (right > left)
        {
            RightScoreText.text = "WIN";
            LeftScoreText.text = "LOSE";
        }
        else
        {
            RightScoreText.text = "DRAW";
            LeftScoreText.text = "DRAW";
        }
    }
}
