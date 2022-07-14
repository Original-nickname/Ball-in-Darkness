using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public bool isLose = false;
    
    private LightController[] allLights;
    public static GameManager instanse = null;
    private AudioController audioController;

    private void Awake()
    {
        if (!instanse)
        {
           instanse = this;
        }
    }

    void Start()
    {
        allLights = FindObjectsOfType<LightController>();
        audioController = FindObjectOfType<AudioController>();
    }

    public void Lose()
    {
        isLose = true;
        LightSwitch(false);
        audioController.PlayLoseSound();
    }

    public void RestartGame()
    {
        isLose = false;
        LightSwitch(true);
    }

    void LightSwitch(bool isLightOn)
    {
        for (int i = 0; i < allLights.Length; i++)
        {
            allLights[i].getLight.enabled = isLightOn;
        }
    }
}
