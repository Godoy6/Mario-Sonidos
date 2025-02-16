using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;  // Valor de la moneda que se va a recoger
    public AudioClip Audio;  // Sonido que se reproduce al recoger la moneda

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<LateralMovements>()) // Si el objeto que colisiona tiene el script "LateralMovements"
        {
            AudioManager.instance.PlayAudio(Audio , "Coin"); // Reproduce el sonido asociado a la moneda
            GameManager.instance.AddCoin(value); // A�ade el valor de la moneda al total de monedas del juego
            Debug.Log("Monedas :     " + GameManager.instance.GetCoins()); // Muestra el n�mero de monedas en la consola para depuraci�n
            Destroy(gameObject); // Destruye la moneda despu�s de que haya sido recogida
        }
    }
}