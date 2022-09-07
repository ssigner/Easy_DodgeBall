
using TMPro;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class addNum : UdonSharpBehaviour
{
    public TextMeshProUGUI ScoreText;
    public GameObject resetCube;
    int score = 0;
    void Start()
    {
    }
    public void OnEnable()
    {
        if (resetCube.activeInHierarchy)
        {
            score = 0;
            resetCube.SetActive(false);
            this.gameObject.SetActive(false);
        }
        else
        {
            score++;
            ScoreText.text = score.ToString();
            this.gameObject.SetActive(false);
        }
    }
}
