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

    public void StartGame() // Función que se llama cuando se pulsa el botón "Jugar"
    {
        // Cargar la escena de juego (asegúrate de que la escena esté en las opciones de Build Settings)

        SceneManager.LoadScene("SampleScene");  // Asegúrate de poner el nombre de tu escena de juego aquí
    }

    public void ReturnToMainMenu()
    {
        // Cargar la escena del menú principal

        SceneManager.LoadScene("Menu Inicio");  // Asegúrate de poner el nombre correcto de la escena del menú
    }
}