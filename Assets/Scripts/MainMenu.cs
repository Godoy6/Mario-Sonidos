using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartGame() // Funci�n que se llama cuando se pulsa el bot�n "Jugar"
    {
        // Cargar la escena de juego (aseg�rate de que la escena est� en las opciones de Build Settings)

        SceneManager.LoadScene("SampleScene");  // Aseg�rate de poner el nombre de tu escena de juego aqu�
    }

    public void ReturnToMainMenu()
    {
        // Cargar la escena del men� principal

        SceneManager.LoadScene("Menu Inicio");  // Aseg�rate de poner el nombre correcto de la escena del men�
    }
}