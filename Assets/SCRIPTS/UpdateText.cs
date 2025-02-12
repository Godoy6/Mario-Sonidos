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
                textComponent.text = "Coins: " + GameManager.instance.GetCoins();
                break;
            case InterfaceVariable.TIMES:
                textComponent.text = "Time: " + GameManager.instance.GetTime();
                break;
        }
    }
}