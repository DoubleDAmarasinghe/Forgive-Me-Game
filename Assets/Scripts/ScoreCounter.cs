using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public TMP_Text scoreText;
    Blocks testobject;
    private GameObject test;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        testobject = GameObject.FindWithTag("Blocks").GetComponent<Blocks>();
    }

    public void SetScore()
    {
        score += testobject.scorePoint;
        //if game object attached to this game object
        //score += gameObject.GetComponent<Blocks>().scorePoint;
        Debug.Log(score);
        scoreText.text = score.ToString();
    }
}
