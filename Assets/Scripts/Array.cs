using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Array : MonoBehaviour
{
    public GameObject[] objectsArray;
    //public Rigidbody[] allRigidbodies;
    public Light[] lightAll;

    void Start()
    {
        //allRigidbodies = FindObjectsOfType<Rigidbody>();
        //objectsArray[0].name = "Element 1";
        //objectsArray[0].GetComponent<Renderer>().material.color = Color.yellow;
        //objectsArray[1].GetComponent<Renderer>().material.color = Color.red;

        for(int i = 0; i < objectsArray.Length; i++)
        {
            objectsArray[i].GetComponent<Renderer>().material.color = Color.red;
            objectsArray[i].AddComponent<Rigidbody>();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            for (int i = 0; i < objectsArray.Length; i++)
            {
                objectsArray[i].GetComponent<Rigidbody>().AddForce(0, 10f, 0);
            }
            for (int i = 0; i < lightAll.Length; i++)
            {
                lightAll[i].color = Color.red;
            }
        } 
        else
        {
            for (int i = 0; i < lightAll.Length; i++)
            {
                lightAll[i].color = Color.white;
            }
        }
    }
}
