using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorJuego : MonoBehaviour
{
    private bool juegoTerminado = false;

    public void TerminarJuego()
    {
        if (juegoTerminado) return;

        juegoTerminado = true;

        Invoke(nameof(Reiniciar), 1.5f);
    }

    private void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}