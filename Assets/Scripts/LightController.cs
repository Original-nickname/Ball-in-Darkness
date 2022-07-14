using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private Transform player;
    public Transform ground;
    private Light myLight;
    public Color goodColor;
    public Color badColor;

    public Light getLight { get => myLight; }

    private void Start()
    {
        player = FindObjectOfType<Player>().transform;
        myLight = GetComponent<Light>();
    }


    private void Update()
    {
        //transform.position = new Vector3(player.position.x, transform.position.y, player.position.z);
        ChangeLightColor();
    }

    private void ChangeLightColor()
    {
        float distanceToBoundary = GetMinDistanceToBound();
        Debug.Log(distanceToBoundary);
        float t = Mathf.InverseLerp(0, ground.localScale.x / 2, distanceToBoundary);
        myLight.color = Color.Lerp(badColor, goodColor, t);
    }

    private float GetMinDistanceToBound() => Mathf.Min(GetAllDistanceToBound());

    private float[] GetAllDistanceToBound() {
        float zBound = ground.position.z + ground.localScale.z / 2;
        float xBound = ground.position.x + ground.localScale.x / 2;

        float[] bounds = {
            player.transform.position.x + xBound,
            xBound - player.transform.position.x,
            player.transform.position.z + zBound,
            zBound - player.transform.position.z
        };

        return bounds;
    }

    //private float GetMinDistanceToBound() 
    //{
    //float[] bounds = GetAllDistanceToBound();

    //float minDistance = Mathf.Min(GetAllDistanceToBound());
    //return Mathf.Min(GetAllDistanceToBound());
    //}
}
