using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private static bool color;
    private  bool ballColor;
    public static int score;
    public static int bestScore = 0;
    public  Text gameScore;
    //public static ball thisBall;

    // Start is called before the first frame update
    void Start()
    {
        color = true;
        score = 0;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        ball thisBall = col.gameObject.GetComponent(typeof(ball)) as ball;

        ballColor = thisBall.getColor();
        if ( color != ballColor)
        {
            if(bestScore < score) bestScore = score;
            Reset();
            resetScore();
        }
        if (color == ballColor)
        {
            score++;
            //Destroy(thisBall, 0.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) color = !color;

        if (color) GetComponent<Renderer>().material.color = new Color(0, 0, 0);

        else if (!color) GetComponent<Renderer>().material.color = new Color(255, 255, 255);


        //reset on letter Q
        if (Input.GetKeyDown("q")) hardReset();
    }

    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void hardReset()
    {
        bestScore = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void resetScore(){ score = 0;}

    public static int getScore()
    {
        return score;
    }
}
