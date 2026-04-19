using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // UI
    private Label puntajeLabel;
    private Button botonPausa;
    private Button botonReanudar;
    private Button botonSalir;
    private VisualElement panelPausa;

    // Lógica
    private float puntos = 0f;
    private float velocidad = 10f;
    private bool enPausa = false;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Referencias UI (IMPORTANTE: nombres exactos)
        puntajeLabel = root.Q<Label>("puntajeLabel");
        botonPausa = root.Q<Button>("btnpause");
        botonReanudar = root.Q<Button>("btnreanudar");
        botonSalir = root.Q<Button>("btnbackmenu");
        panelPausa = root.Q<VisualElement>("panelpause");

        // Ocultar panel al inicio
        panelPausa.style.display = DisplayStyle.None;

        // Eventos botones
        botonPausa.clicked += TogglePausa;
        botonReanudar.clicked += TogglePausa;
        botonSalir.clicked += IrAlMenu;
    }

    void Update()
    {
        if (!enPausa)
        {
            puntos += velocidad * Time.deltaTime;
            puntajeLabel.text = "Puntos: " + Mathf.FloorToInt(puntos);
        }
    }

    void TogglePausa()
    {
        enPausa = !enPausa;

        if (enPausa)
        {
            Time.timeScale = 0f;
            panelPausa.style.display = DisplayStyle.Flex;

            // Ocultar HUD
            puntajeLabel.style.display = DisplayStyle.None;
            botonPausa.style.display = DisplayStyle.None;
        }
        else
        {
            Time.timeScale = 1f;
            panelPausa.style.display = DisplayStyle.None;

            // Mostrar HUD
            puntajeLabel.style.display = DisplayStyle.Flex;
            botonPausa.style.display = DisplayStyle.Flex;
        }
    }

    void IrAlMenu()
    {
        Time.timeScale = 1f; // 🔥 importante resetear pausa
        SceneManager.LoadScene("Main menu"); // 👈 nombre exacto de tu escena
    }
}