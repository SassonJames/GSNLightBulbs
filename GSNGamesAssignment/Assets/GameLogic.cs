using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour
{

    public List<GameObject> allLights;
    public Material selectedMaterial;
    private int gameState;
    private int previousGameState;
    public Vector2 lightOne;
    public Vector2 lightTwo;

    // Use this for initialization
    void Start()
    {
        GameObject[] lights = GameObject.FindGameObjectsWithTag("Light");
        foreach (GameObject light in lights)
        {
            allLights.Add(light);
        }

        gameState = 0;
        previousGameState = -1;
    }

    // Update is called once per frame
    void Update()
    {
        PresentOption();
        CheckClick();
    }

    public void PresentOption()
    {
        if (gameState != previousGameState)
        {
            switch (gameState)
            {
                case 0:
                    Debug.Log("Please Choose Your First Bulb...");
                    previousGameState = 0;
                    break;
                case 1:
                    Debug.Log("Please Choose Your Second Bulb...");
                    previousGameState = 1;
                    break;
                case 2:
                    ToggleLights();
                    Debug.Log("DING!!!");
                    previousGameState = 2;
                    gameState = 0;
                    break;
            }
        }
    }
    public void ChooseLight(float x, float y)
    {
        switch (gameState)
        {
            case 0:
                lightOne.x = x;
                lightOne.y = y;
                gameState = 1;
                break;
            case 1:
                if (lightOne.x != x)
                {
                    if (lightOne.y != y)
                    {
                        lightTwo.x = x;
                        lightTwo.y = y;
                        gameState = 2;
                        break;
                    }
                    else
                    {
                        Debug.Log("Please choose a light with a different Y Value.");
                        break;
                    }
                }
                else
                {
                    Debug.Log("Please choose a light with a different X Value.");
                    break;
                }
        }
    }
    public void CheckClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float distance = 10000;
            Vector3 lightClickedPos = new Vector3();
            GameObject selectedLight = null;
            foreach(GameObject light in allLights)
            {
                float currentDist = Vector3.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), light.transform.position);
                if(currentDist < distance)
                {
                    lightClickedPos = light.transform.position;
                    distance = currentDist;
                    selectedLight = light;
                }
            }
            selectedLight.GetComponent<MeshRenderer>().material = selectedMaterial;
            ChooseLight(lightClickedPos.x, lightClickedPos.y);
        }
    }
    public void ToggleLights()
    {
        if (lightOne.x > lightTwo.x)
        {
            if (lightOne.y > lightTwo.y)
            {
                foreach (GameObject light in allLights)
                {
                    if (light.transform.position.x <= lightOne.x && light.transform.position.x >= lightTwo.x && light.transform.position.y <= lightOne.y && light.transform.position.y >= lightTwo.y)
                    {
                        light.GetComponent<ToggleLight>().SwitchLight();
                    }

                }
            }
            else
            {
                foreach (GameObject light in allLights)
                {
                    if (light.transform.position.x <= lightOne.x && light.transform.position.x >= lightTwo.x && light.transform.position.y >= lightOne.y && light.transform.position.y <= lightTwo.y)
                    {
                        light.GetComponent<ToggleLight>().SwitchLight();
                    }

                }
            }
        }
        else
        {
            if (lightOne.y > lightTwo.y)
            {
                foreach (GameObject light in allLights)
                {
                    if (light.transform.position.x >= lightOne.x && light.transform.position.x <= lightTwo.x && light.transform.position.y <= lightOne.y && light.transform.position.y >= lightTwo.y)
                    {
                        light.GetComponent<ToggleLight>().SwitchLight();
                    }

                }
            }
            else
            {
                foreach (GameObject light in allLights)
                {
                    if (light.transform.position.x >= lightOne.x && light.transform.position.x <= lightTwo.x && light.transform.position.y >= lightOne.y && light.transform.position.y <= lightTwo.y)
                    {
                        light.GetComponent<ToggleLight>().SwitchLight();
                    }

                }
            }
        }
    }
}
