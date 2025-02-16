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

    public void StartGame() // M�todo para iniciar el juego, cargando la escena "SampleScene"
    {
        SceneManager.LoadScene("SampleScene"); // Cargar la escena principal del juego
    }

    public void ReturnToMainMenu() // M�todo para volver al men� principal, cargando la escena "Menu Inicio"
    {
        SceneManager.LoadScene("Menu Inicio"); // Cargar la escena del men� principal
    }
}