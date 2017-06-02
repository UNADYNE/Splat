using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class US_GameManager : MonoBehaviour
{
    public int score;
    public Text scoreNum;
    public List<Transform> coinPositions = new List<Transform>();
    public GameObject coin;
    public AudioClip coinSound;
    public AudioSource audioSource;

    void Start()
    {
        US_PoolManager.instance.CreatePool(coin, coinPositions.Count);
        audioSource = GetComponent<AudioSource>();
        PlaceCoins();
    }

    void LateUpdate()
    {
        scoreNum.text = score.ToString();
    }

    void PlaceCoins()
    {
        foreach(Transform pos in coinPositions)
        {
            US_PoolManager.instance.ActivatePoolObject(coin, pos.position, pos.rotation);
        }
    }
}
