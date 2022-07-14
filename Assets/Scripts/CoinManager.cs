using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public List<Coin> CoinsList = new List<Coin>();
    public GameObject coinPrefab;
    public Text coinText;
    public GameObject bloodMarkPrefab;
    private AudioController audioController;

    void Start()
    {
        audioController = FindObjectOfType<AudioController>();

        for(int i = 0; i < 50; i++)
        {
            Vector3 position = new Vector3(Random.Range(-20f, 20f), 0.5f, Random.Range(-20f, 20f));
            GameObject newCoin = Instantiate(coinPrefab, position, Quaternion.identity);
            CoinsList.Add(newCoin.GetComponent<Coin>());
        }

        UpdateText();
    }

    public void CollectCoin (Coin coin)
    {
        CoinsList.Remove(coin);
        Destroy(coin.gameObject);
        Vector3 bloodPosition = new Vector3(coin.transform.position.x, 0, coin.transform.position.z);
        Instantiate(bloodMarkPrefab, bloodPosition, coin.transform.rotation);
        UpdateText();
        audioController.PlayDeathSound();
    }

    void UpdateText()
    {
        coinText.text = "Осталось собрать " + CoinsList.Count.ToString();
    }

    public Coin GetClosest(Vector3 point)
    {
        float minDistance = Mathf.Infinity;
        Coin closesCoin = null;
        
        for(int i = 0; i < CoinsList.Count; i++)
        {
            float distance = Vector3.Distance(point, CoinsList[i].transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closesCoin = CoinsList[i];
            }
        }

        return closesCoin;
    }
 }
