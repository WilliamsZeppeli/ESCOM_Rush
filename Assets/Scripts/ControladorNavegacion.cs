using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorNavegacion : MonoBehaviour
{
    // --- 1. ESCENA: ModoJuego (Menú Principal) ---
    
    // Para el botón PLAY
    public void IrAModos()
    {
        SceneManager.LoadScene("ModoJuego");
    }

    // Para el botón OPTIONS
    public void IrAOpciones()
    {
        SceneManager.LoadScene("Opciones");
    }

    // --- 2. ESCENA: Modos_H_I (Selección de Modo) ---

    // Para el botón HISTORIA
    public void IrASeleccionNivel()
    {
        SceneManager.LoadScene("SeleccionNivel");
    }

    // Para el botón INFINITO
    public void IrAJuegoInfinito()
    {
        SceneManager.LoadScene("Juego");
    }

    // Para el botón REGRESAR (vuelve al inicio)
    public void RegresarAModoJuego()
    {
        SceneManager.LoadScene("ModoJuego");
    }

    // --- 3. ESCENA: SeleccionNivel (Casilleros) ---

    // Para el botón REGRESAR (vuelve a selección de modo)
    public void RegresarAModos()
    {
        SceneManager.LoadScene("ModoJuego");
    }

    // --- 4. ESCENA: Opciones ---

    // Para el botón BACK en opciones (vuelve al inicio)
    public void RegresarAlMenu()
    {
        SceneManager.LoadScene("ModoJuego");
    }
    public void IrAMain()
    {
        SceneManager.LoadScene("Main menu");
    }
}