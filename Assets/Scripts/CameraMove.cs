using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform playerTransform;
    public Rigidbody playerRigidbody;

    public List<Vector3> velocitiesList = new List<Vector3>();

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            velocitiesList.Add(Vector3.zero);
        }
    }

    private void FixedUpdate()
    {
        velocitiesList.Add(playerRigidbody.velocity);
        velocitiesList.RemoveAt(0);
    }

    void Update()
    {
        Vector3 sum = Vector3.zero;

        for (int i = 0; i < velocitiesList.Count; i++)
        {
            sum += velocitiesList[i];
        }

        transform.position = playerTransform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(sum), Time.deltaTime * 10); // thdesia was domashka
    }
}
