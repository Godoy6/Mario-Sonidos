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

    public void StartGame() // Método para iniciar el juego, cargando la escena "SampleScene"
    {
        SceneManager.LoadScene("SampleScene"); // Cargar la escena principal del juego
    }

    public void ReturnToMainMenu() // Método para volver al menú principal, cargando la escena "Menu Inicio"
    {
        SceneManager.LoadScene("Menu Inicio"); // Cargar la escena del menú principal
    }
}