using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SeleccionPersonajes : MonoBehaviour
{
    [Header("Referencias de UI")]
    public Image imagenPersonajeDisplay; // El cuadro blanco del centro

    [Header("Lista de Personajes")]
    public Sprite[] spritesPersonajes; // Los 7 sprites de ESCOM Rush

    private int indiceActual = 0;

    void Start()
    {
        // Al arrancar, cargamos el personaje guardado en memoria (por defecto el 0)
        indiceActual = PlayerPrefs.GetInt("PersonajeSeleccionado", 0);
        ActualizarPantalla();
    }

    public void SiguientePersonaje()
    {
        indiceActual++;
        if (indiceActual >= spritesPersonajes.Length)
        {
            indiceActual = 0; // Si pasa del último, regresa al primero
        }
        ActualizarPantalla();
    }

    public void AnteriorPersonaje()
    {
        indiceActual--;
        if (indiceActual < 0)
        {
            indiceActual = spritesPersonajes.Length - 1; // Si baja de 0, va al último
        }
        ActualizarPantalla();
    }

    void ActualizarPantalla()
    {
        if (spritesPersonajes.Length > 0 && imagenPersonajeDisplay != null)
        {
            imagenPersonajeDisplay.sprite = spritesPersonajes[indiceActual];
        }
    }

    public void ConfirmarSeleccion()
    {
        // Guarda la elección en el disco duro local
        PlayerPrefs.SetInt("PersonajeSeleccionado", indiceActual);
        PlayerPrefs.Save();

        // Carga la escena de la carrera (asegúrate de que tu escena principal se llame "Juego")
        SceneManager.LoadScene("Juego"); 
    }
}