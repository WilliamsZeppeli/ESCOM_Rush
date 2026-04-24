using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Importante para manejar los textos

public class ModoSystem : MonoBehaviour
{
    // Variables para los textos de volumen (los arrastraremos en Unity)
    public TextMeshProUGUI txtVolumen;
    int nivelVolumen = 100;

    // --- NAVEGACIÓN ---

    public void Historia() => SceneManager.LoadScene("SeleccionNivel");
    
    public void AbrirOpciones() => SceneManager.LoadScene("Opciones");

    public void RegresarAlMenu() => SceneManager.LoadScene("ModoJuego"); 

    public void SalirDelJuego() 
    {
        Debug.Log("Saliendo...");
        Application.Quit();
    }

    // --- LÓGICA DE OPCIONES ---

    public void SubirVolumen()
    {
        if (nivelVolumen < 100) nivelVolumen += 10;
        ActualizarTexto();
    }

    public void BajarVolumen()
    {
        if (nivelVolumen > 0) nivelVolumen -= 10;
        ActualizarTexto();
    }

    void ActualizarTexto()
    {
        txtVolumen.text = nivelVolumen.ToString();
    }

    public void AplicarCambios()
    {
        Debug.Log("Cambios aplicados. Volumen guardado en: " + nivelVolumen);
        // Aquí podrías guardar el dato realmente, pero por ahora el log nos avisa que sirve
    }
}