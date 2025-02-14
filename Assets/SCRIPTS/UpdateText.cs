using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    public InterfaceVariable variableToUpdate;
    private TMP_Text textComponent;

    void Start()
    {
        textComponent = GetComponent<TMP_Text>();
    }

    void Update()
    {
        switch (variableToUpdate)
        {
            case InterfaceVariable.COINS:
                textComponent.text = "Puntos: " + GameManager.instance.GetCoins();
                break;
            case InterfaceVariable.TIMES:
                textComponent.text = "Tiempo: " + GameManager.instance.GetTime().ToString("F2"); // Mostrar el tiempo con 2 decimal
                break;
        }
    }
}