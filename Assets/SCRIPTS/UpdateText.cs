using System.Collections;
using System.Collections.Generic;
using TMPro; // Importamos el paquete necesario para trabajar con texto en Unity
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    public InterfaceVariable variableToUpdate; // Variable que indica qué información se actualizará (puntos o tiempo)
    private TMP_Text textComponent; // Componente de texto de TMP que se actualizará

    void Start()
    {
        textComponent = GetComponent<TMP_Text>(); // Obtenemos el componente TMP_Text que está en este objeto
    }

    void Update()
    {
        // Dependiendo de la "variableToUpdate", actualizamos el texto que se muestra
        switch (variableToUpdate)
        {
            case InterfaceVariable.COINS: // Si se va a actualizar los puntos, obtenemos la cantidad de monedas del GameManager
                textComponent.text = "Puntos: " + GameManager.instance.GetCoins();
                break;
            case InterfaceVariable.TIMES: // Si se va a actualizar el tiempo, mostramos el tiempo actual con dos decimales
                textComponent.text = "Tiempo: " + GameManager.instance.GetTime().ToString("F2"); // Mostrar el tiempo con 2 decimales
                break;
        }
    }
}