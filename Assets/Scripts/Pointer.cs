using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public CoinManager coinManager;
    //public Coin closestCoin;
    private Transform playerTransform;
    public float rotationSpeed = 3;

    private void Start()
    {
        playerTransform = FindObjectOfType<Player>().transform;
    }

    void Update()
    {
        transform.position = playerTransform.position;

        Coin closestCoin = coinManager.GetClosest(transform.position);
        Vector3 targetPosition = closestCoin.transform.position;
        Vector3 targetPositionXZ = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
        Vector3 direction = targetPositionXZ - transform.position;
        transform.rotation = Quaternion.Lerp(
            transform.rotation, 
            Quaternion.LookRotation(direction), 
            Time.deltaTime * rotationSpeed
        );
    }
}
