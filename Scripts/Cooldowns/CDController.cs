using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDController : MonoBehaviour
{
    public GameObject fire;
    public GameObject rage;
    public GameObject normal;
    public static bool isQuitFire = false;
    public static bool isQuitRage = false;
    public static bool isQuitNormal = false;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            EnableFireCD();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            EnableRageCD();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            EnableNormalCD();
        }

    }

    public void EnableFireCD()
    {
        fire.SetActive(true);
        Time.timeScale = 1f;
        isQuitFire = false;
    }
    public void EnableRageCD()
    {
        rage.SetActive(true);
        Time.timeScale = 1f;
        isQuitRage = false;
    }
    public void EnableNormalCD()
    {
        normal.SetActive(true);
        Time.timeScale = 1f;
        isQuitNormal = false;
    }
}
