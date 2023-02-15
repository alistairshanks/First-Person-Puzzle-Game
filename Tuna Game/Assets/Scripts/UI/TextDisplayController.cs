using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextDisplayController : MonoBehaviour
{
    public GameObject textDisplay;

    private bool startDeleteText;
    private float timer;

    void Start()
    {
        ShowText("Press F to turn the mirrors and make the lazers hit the purple cubes.");
        
    }

    private void Update()
    {
        if (startDeleteText== true)
        {
            timer = timer + Time.deltaTime;
            if (timer >= 3)
            {
                textDisplay.GetComponent<Text>().text = "";
                timer = 0.0f;
                startDeleteText = false;
            }
        }
    }

    public void ShowText(string messageToDisplay)
    {
        startDeleteText = true;
        textDisplay.GetComponent<Text>().text = messageToDisplay;
    }

}
