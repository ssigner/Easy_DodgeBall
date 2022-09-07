
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MiddleWall : UdonSharpBehaviour
{
    public GameObject LeftCube, RightCube, middlewall;
    public Animator WallDown;
    public GameObject LeftReady, RightReady;

    void Start()
    {
    }
    private void FixedUpdate()
    {
        bool GameStart;
        bool CubeOn = !LeftCube.activeInHierarchy&&!RightCube.activeInHierarchy;
        GameStart = !LeftReady.activeInHierarchy && !RightReady.activeInHierarchy;
        if (CubeOn)
        {
            middlewall.SetActive(true);
            WallDown.Play("MiddleWall");
            if (GameStart)
            {
                middlewall.SetActive(false);
            }
        }

    }
}
