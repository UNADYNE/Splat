using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class US_PickUp : MonoBehaviour
{

    [SerializeField]
    float rotationSpeed;
    [SerializeField]
    int scoreValue;
    [SerializeField]
    float despawnDelay;

    US_GameManager gm;
    AudioSource aSource;
    AudioClip coinSound;

    void Start()
    {
        gm = FindObjectOfType<US_GameManager>();
        aSource = GetComponent<AudioSource>();
        coinSound = gm.coinSound;
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            gm.score += scoreValue;
            gm.audioSource.PlayOneShot(coinSound);
            gameObject.SetActive(false);
        }
    }

}/** END OF CLASS */
