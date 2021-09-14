using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrikeCD : MonoBehaviour
{
    Text text;
    float TheTime = 10f;
    public float speed = 1f;
    public GameObject quitCD;
    public static bool isQuit = true;


    void Start()
    {
        text = GetComponent<Text>();
    }


    void Update()
    {


        if (TheTime >= 1f)
        {
            TheTime -= Time.deltaTime * speed;
            string seconds = (TheTime % 10).ToString("0");
            text.text = seconds;
        }
        else
        {
            TheTime = 10f;
            DisableStrikeCD();
        }

    }


    public void DisableStrikeCD()
    {
        quitCD.SetActive(false);
        Time.timeScale = 1f;
        isQuit = true;
    }

}
