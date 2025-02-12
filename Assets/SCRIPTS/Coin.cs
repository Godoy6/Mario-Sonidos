using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;

    public AudioClip Audio;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<LateralMovements>())
        {
            AudioManager.instance.PlayAudio(Audio, "Coin");

            GameManager.instance.AddCoin(value);
            Debug.Log("Monedas :     " + GameManager.instance.GetCoins());
            Destroy(gameObject);
        }
    }
}