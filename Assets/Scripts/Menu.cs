using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    private VisualElement menuPrincipal;
    private VisualElement panelOpciones;

    private Button btnIniciar;
    private Button btnOpciones;
    private Button btnSalir;
    private Button btnRegresar;

    private Slider sliderGeneral;
    private Slider sliderMusica;
    private Slider sliderEfectos;

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        menuPrincipal = root.Q<VisualElement>("menuprincipal");
        panelOpciones = root.Q<VisualElement>("panelopciones");

        btnIniciar = root.Q<Button>("btnIniciar");
        btnOpciones = root.Q<Button>("btnOpciones");
        btnSalir = root.Q<Button>("btnSalir");
        btnRegresar = root.Q<Button>("btnRegresar");

        sliderGeneral = root.Q<Slider>("sliderGeneral");
        sliderMusica = root.Q<Slider>("sliderMusica");
        sliderEfectos = root.Q<Slider>("sliderEfectos");

        menuPrincipal.style.display = DisplayStyle.Flex;
        panelOpciones.style.display = DisplayStyle.None;

        btnIniciar.clicked += IniciarMenu;
        btnOpciones.clicked += AbrirOpciones;
        btnSalir.clicked += SalirJuego;
        btnRegresar.clicked += RegresarMenu;

        sliderGeneral.RegisterValueChangedCallback(CambiarVolumenGeneral);
        sliderMusica.RegisterValueChangedCallback(CambiarVolumenMusica);
        sliderEfectos.RegisterValueChangedCallback(CambiarVolumenEfectos);
    }

    private void OnDisable()
    {
        if (btnIniciar != null) btnIniciar.clicked -= IniciarMenu;
        if (btnOpciones != null) btnOpciones.clicked -= AbrirOpciones;
        if (btnSalir != null) btnSalir.clicked -= SalirJuego;
        if (btnRegresar != null) btnRegresar.clicked -= RegresarMenu;

        if (sliderGeneral != null) sliderGeneral.UnregisterValueChangedCallback(CambiarVolumenGeneral);
        if (sliderMusica != null) sliderMusica.UnregisterValueChangedCallback(CambiarVolumenMusica);
        if (sliderEfectos != null) sliderEfectos.UnregisterValueChangedCallback(CambiarVolumenEfectos);
    }

    private void IniciarMenu()
    {
        SceneManager.LoadScene("ModoJuego");
    }

    private void AbrirOpciones()
    {
        menuPrincipal.style.display = DisplayStyle.None;
        panelOpciones.style.display = DisplayStyle.Flex;
    }

    private void RegresarMenu()
    {
        panelOpciones.style.display = DisplayStyle.None;
        menuPrincipal.style.display = DisplayStyle.Flex;
    }

    private void SalirJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

    private void CambiarVolumenGeneral(ChangeEvent<float> evt)
    {
        AudioListener.volume = evt.newValue;
        Debug.Log("Volumen general: " + evt.newValue);
    }

    private void CambiarVolumenMusica(ChangeEvent<float> evt)
    {
        Debug.Log("Volumen música: " + evt.newValue);
    }

    private void CambiarVolumenEfectos(ChangeEvent<float> evt)
    {
        Debug.Log("Volumen efectos: " + evt.newValue);
    }
}