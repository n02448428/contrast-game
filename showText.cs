using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showText : MonoBehaviour
{

    public string displayText;
    public showText textElement;

    private Text text;

    Camera exampleCam;

    private int g;

    void Awake()
    {
        exampleCam = new Camera();
        //exampleCam.enabled = true;
        g = 0;

        Font arial;
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        GameObject canvasGO = new GameObject();
        canvasGO.name = "Canvas1";
        canvasGO.AddComponent<Canvas>();
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();
        canvasGO.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 1);

        Canvas canvas;
        canvas = canvasGO.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        RectTransformUtility.WorldToScreenPoint(Camera.main, canvas.transform.position);
        //canvas.worldCamera = Camera.main;
        //canvas.plane.distance = 13;
        //canvas.rectTransform.localScale = new Vector3(1f, 1f, 1f);

        canvas.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 1);
        RectTransform canvasRect;
        canvasRect = canvas.GetComponent<RectTransform>();
        canvasRect.localPosition = new Vector3(0,0,0);
        //canvas.GetComponent<RectTransform>().rectTransform = canvasRect;
        //Camera cam =
        //canvas.worldCamera = MainCamera;
        //canvas.renderMode.planeDistance = 13;

        GameObject textGO = new GameObject();
        textGO.transform.parent = canvasGO.transform;
        textGO.AddComponent<Text>();

        textGO.name = "Screen Text";

        text = textGO.GetComponent<Text>();
        text.font = arial;
        text.text = "  CONTRAST \n" +
            "^ " + Player.bestScore + " ^" ;
        text.fontSize = 28;
        text.GetComponent<Text>().color = Color.gray;
        text.alignment = TextAnchor.MiddleCenter;

        RectTransform rectTransform;
        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -150, 0);
        rectTransform.sizeDelta = new Vector2(600, 200);

        //canvas.setResolution(1920, 1020, false);

    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (g < Player.getScore())
        {
            g = Player.getScore();
            text.fontSize = 36;
            text.text = "~ " + g + " ~";
        }
    }
}
