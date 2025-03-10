using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createBall : MonoBehaviour
{
    public GameObject ballPrefab;
    private Vector2 screenBounds;
    public bool isFalling = true;
    private int ballNum;


    [Header("Speed of New Ball")]
    [Range(10, 2000)] public float ballSpeed = 400;
    [Range(0, 50)] public float ballSpeedIncrement = 6;
    [Range(100, 2000)] public float ballSpeedMax = 1000;

    [Header("Spawn Rate of New Ball")]
    [Range(0.05f, 10)] public float respawnRate = 2.3f;
    [Range(0f, 1f)] public float respawnDecrement = 0.02f;
    [Range(0.1f, 3)] public float respawnTimeMinimum = 0.3f;

    private GameObject thisBall;

    // Start is called before the first frame update
    void Start()
    {
        ballNum = 0;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(ballWave());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("v")) create();
        if (Input.GetKeyDown("f")) isFalling = !isFalling;
    }

    private void create()
    {
        ball thisBall = ballPrefab.GetComponent(typeof(ball)) as ball;
        thisBall.setColor(Random.value > 0.5f);
        ballNum++;
        thisBall.name = "ball #" + ballNum;
        thisBall.speed = ballSpeed;
        thisBall.incSpeed(ballSpeedIncrement, ballSpeedMax);
        ballSpeed += ballSpeedIncrement;
        decSpawn(respawnDecrement, respawnTimeMinimum);

        Instantiate(thisBall);
    }

    //decrement respawn rate
    void decSpawn(float dec, float min)
    {
        if ( respawnRate >= min ) respawnRate -=  dec;
    }

    IEnumerator ballWave()
    {
        while (true)
        { 
            yield return new WaitForSeconds(respawnRate);
            if (isFalling) create();
        }
    }
}
