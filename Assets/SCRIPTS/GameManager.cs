using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InterfaceVariable {TIMES,COINS};

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private float currentGameTime = 000.0f;
    private int coins = 0;

    void Awake()
    {
        /*SINGLETON*/
        if (!instance) // instance == null
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    void Update()
    {
        currentGameTime += Time.deltaTime;
    }

    public float GetTime()
    {
        return currentGameTime;
    }

    public void AddCoin(int value)
    {
        coins += value;
    }

    public float GetCoins()
    {
        return coins;
    }
}