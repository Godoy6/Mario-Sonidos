using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;

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
            GameManager.instance.AddCoin(value);
            Debug.Log("Monedas :     " + GameManager.instance.GetCoins());
            Destroy(gameObject);
        }
    }
}