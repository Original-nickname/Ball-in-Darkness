using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CoinManager coinManager;

    private Rigidbody rb;
    public float torqueValue;

    public Transform cameraCenter;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 500f;
    }

    private void Update()
    {
        if (!GameManager.instanse.isLose && transform.position.y < -1)
        {
            GameManager.instanse.Lose();
        }

        if (GameManager.instanse.isLose)
        {
            if (transform.position.y < -7)
            {
                transform.position = new Vector3(0f, 32f, 0f);
            }
            else if (transform.position.y < 10f && transform.position.y > 0)
            {
                GameManager.instanse.RestartGame();
            }
        }
    }

    private void FixedUpdate()
    {
        float verticalOnlyForward = Input.GetAxis("Vertical") >= 0 ? Input.GetAxis("Vertical") : 0;
        rb.AddTorque(cameraCenter.right * verticalOnlyForward * torqueValue);
        rb.AddTorque(-cameraCenter.forward * Input.GetAxis("Horizontal") * torqueValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        Coin coin = other.GetComponent<Coin>();
        if (coin)
        {
            coinManager.CollectCoin(coin);
        }
    }


}
