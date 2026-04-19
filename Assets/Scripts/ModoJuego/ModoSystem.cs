using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModoSystem : MonoBehaviour
{
    public void Historia()
    {
        //SceneManager.LoadScene("Historia"); --> modificar cuando se tenga la escena de historia
        Debug.Log("Pantalla: Seleccion de niveles");
    }
    
    public void Infinito()
    {
        SceneManager.LoadScene("Juego");
    }

    public void Regresar()
    {
        SceneManager.LoadScene("Main menu");
    }
}
