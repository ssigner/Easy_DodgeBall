
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;
public class IsReady : UdonSharpBehaviour
{
    public TextMeshProUGUI[] NowReady = new TextMeshProUGUI[2];
    public GameObject[] LeftCube = new GameObject[2];
    public GameObject[] RightCube = new GameObject[2];
    public GameObject[] ReadyCube = new GameObject[2];
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        bool LeftTeamFinish = !LeftCube[0].activeInHierarchy && !LeftCube[1].activeInHierarchy;
        bool RightTeamFinish = !RightCube[0].activeInHierarchy && !RightCube[1].activeInHierarchy;
        if (LeftTeamFinish && RightTeamFinish)
        {
            for(int i = 0; i < ReadyCube.Length; i++)
            {
                if (!NowReady[i].gameObject.activeInHierarchy)
                {
                    ReadyCube[i].SetActive(true);
                }
            }
        }
    }
}
