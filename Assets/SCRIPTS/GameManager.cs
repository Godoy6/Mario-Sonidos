using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InterfaceVariable {TIMES , COINS}; // Enumeraci�n para las variables de la interfaz, como el tiempo y las monedas

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Instancia est�tica para implementar el patr�n Singleton
    private float currentGameTime = 0.0f; // Tiempo de juego actual
    private int coins = 0; // Cantidad de monedas recogidas

    void Awake()
    {
        /*SINGLETON*/
        if (!instance) // Si la instancia a�n no existe
        {
            instance = this; // Asigna esta instancia a la variable est�tica
            DontDestroyOnLoad(gameObject); // Hace que el objeto no se destruya al cargar una nueva escena
        }
        else
        {
            Destroy(gameObject); // Si ya existe una instancia, destruye este objeto
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        currentGameTime += Time.deltaTime; // Incrementa el tiempo de juego en funci�n del tiempo transcurrido cada frame
    }

    public float GetTime() // Devuelve el tiempo de juego actual
    {
        return currentGameTime;
    }

    public void AddCoin(int value) // A�ade el valor de las monedas recogidas al total
    {
        coins += value;
    }

    public float GetCoins() // Devuelve el n�mero total de monedas
    {
        return coins;
    }
}