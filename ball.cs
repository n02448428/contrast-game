using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ball : MonoBehaviour
{
    [Header("Speed Of Ball 1-1000")]
    [Range(10, 1000)]
    [SerializeField] public float speed = 500.0f;
    private Rigidbody2D rb;

    [Header("Color Of Ball")]
    [SerializeField] public bool color;
    private Vector2 screenBounds;

    public global::System.Single Speed { get => speed; set => speed = value; }

    // Start is called before the first frame update
    void Start()
    {
        // make fall
        updateSpeed();

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));


    }

    void updateSpeed()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(0, -(speed));
    }

    // Update is called once per frame
    void Update()
    {

        if(this.transform.position.y <= -600) Destroy(gameObject);

        updateSpeed();

        //render correct color
        if (color) GetComponent<Renderer>().material.color = new Color(0, 0, 0);
        else GetComponent<Renderer>().material.color = new Color(255, 255, 255);

        if (Input.GetKeyDown("d")) Destroy(gameObject);

    }

    public  bool getColor()
    {
        return color;
    }

    public void setColor(bool b)
    {
        color = b;
    }

    public void incSpeed(float inc, float max)
    {
        if ( speed <= max ) speed += inc;
    }

}
