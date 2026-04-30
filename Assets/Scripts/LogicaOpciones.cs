using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicaOpciones : MonoBehaviour
{
    // Arrastra aquí los textos que dicen "100"
    public TextMeshProUGUI textoVolumen;
    public TextMeshProUGUI textoSonido;

    int valorVolumen = 100;
    int valorSonido = 100;

    // Funciones para Volumen
    public void MasVolumen() { if (valorVolumen < 100) valorVolumen += 10; ActualizarTextos(); }
    public void MenosVolumen() { if (valorVolumen > 0) valorVolumen -= 10; ActualizarTextos(); }

    // Funciones para Sonido
    public void MasSonido() { if (valorSonido < 100) valorSonido += 10; ActualizarTextos(); }
    public void MenosSonido() { if (valorSonido > 0) valorSonido -= 10; ActualizarTextos(); }

    void ActualizarTextos()
    {
        textoVolumen.text = valorVolumen.ToString();
        textoSonido.text = valorSonido.ToString();
    }

    public void AplicarCambios()
    {
        // Aquí podrías guardar los datos con PlayerPrefs si quisieras
        Debug.Log("Cambios Aplicados: Vol " + valorVolumen + " Sonido " + valorSonido);
    }

    public void Regresar()
    {
        // Asegúrate de que tu escena principal se llame exactamente "ModoJuego"
        SceneManager.LoadScene("ModoJuego");
    }
}