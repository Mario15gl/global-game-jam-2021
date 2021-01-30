﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterCustomization : MonoBehaviour
{
    public GameObject hat;
    public GameObject glasses;
    public GameObject cape;


    bool hasHat;
    bool hasGlasses;
    bool hasCape;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("hat") && PlayerPrefs.GetInt("hat") == 1)
        {
            hasHat = true;
        }
        if (PlayerPrefs.HasKey("glasses") && PlayerPrefs.GetInt("glasses") == 1)
        {
            hasGlasses = true;
        }
        if (PlayerPrefs.HasKey("cape") && PlayerPrefs.GetInt("cape") == 1)
        {
            hasCape = true;
        }

        if (hasHat == true)
        {
            hat.SetActive(true);
        }
        if (hasGlasses == true)
        {
            glasses.SetActive(true);
        }
        if (hasCape == true)
        {
            cape.SetActive(true);
        }
    }

    public void putHat()
    {
        if (hasHat == false)
        {
            hasHat = true;
            hat.SetActive(true);
            PlayerPrefs.SetInt("hat", 1);
        }
        else 
        {
            hasHat = false;
            hat.SetActive(false);
            PlayerPrefs.SetInt("hat", 0);
        }
    }

    public void putGlasses()
    {
        if (hasGlasses == false)
        {
            hasGlasses = true;
            glasses.SetActive(true);
            PlayerPrefs.SetInt("glasses", 1);
        }
        else
        {
            hasGlasses = false;
            glasses.SetActive(false);
            PlayerPrefs.SetInt("glasses", 0);
        }
    }

    public void putCape()
    {
        if (hasCape == false)
        {
            hasCape = true;
            cape.SetActive(true);
            PlayerPrefs.SetInt("cape", 1);
        }
        else
        {
            hasCape = false;
            cape.SetActive(false);
            PlayerPrefs.SetInt("cape", 0);
        }
    }
}
