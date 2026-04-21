using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectorNivelesUI : MonoBehaviour
{
    [Header("Contenedor que se anima")]
    public RectTransform contenedorCasilleros;

    [Header("Botones UI")]
    public Button btnIzquierda;
    public Button btnDerecha;
    public Button btnRegresar;

    [Header("Botones de niveles (1 al 9)")]
    public Button[] botonesNivel = new Button[9];

    [Header("Escenas de niveles (en orden)")]
    public string[] escenasNiveles = new string[9];

    [Header("Escena a la que regresa")]
    public string escenaRegreso = "ModoJuego";

    [Header("Vista completa inicial")]
    public Vector2 posicionVistaCompleta = new Vector2(0f, 0f);
    public Vector3 escalaVistaCompleta = new Vector3(1f, 1f, 1f);

    [Header("Posiciones por piso")]
    public Vector2 posicionPiso1 = new Vector2(0f, -600f);
    public Vector2 posicionPiso2 = new Vector2(0f, -50f);
    public Vector2 posicionPiso3 = new Vector2(0f, 500f);
    public Vector3 escalaPisos = new Vector3(2f, 2f, 1f);

    [Header("Tiempos")]
    public float esperaInicial = 0.8f;
    public float duracionMovimiento = 0.8f;

    private int pisoActual = 0; // 0 = vista completa, 1 = piso 1, 2 = piso 2, 3 = piso 3
    private bool animando = false;

    void Start()
    {
        ConfigurarBotones();

        contenedorCasilleros.anchoredPosition = posicionVistaCompleta;
        contenedorCasilleros.localScale = escalaVistaCompleta;

        CambiarEstadoFlechas(false);
        CambiarEstadoBotonesNivel(false);

        StartCoroutine(AnimacionEntrada());
    }

    void ConfigurarBotones()
    {
        if (btnIzquierda != null)
        {
            btnIzquierda.onClick.RemoveAllListeners();
            btnIzquierda.onClick.AddListener(IrIzquierda);
        }

        if (btnDerecha != null)
        {
            btnDerecha.onClick.RemoveAllListeners();
            btnDerecha.onClick.AddListener(IrDerecha);
        }

        if (btnRegresar != null)
        {
            btnRegresar.onClick.RemoveAllListeners();
            btnRegresar.onClick.AddListener(RegresarAModoJuego);
        }

        for (int i = 0; i < botonesNivel.Length; i++)
        {
            if (botonesNivel[i] == null) continue;

            int indiceCapturado = i;
            botonesNivel[i].onClick.RemoveAllListeners();
            botonesNivel[i].onClick.AddListener(() => CargarNivel(indiceCapturado));
        }
    }

    IEnumerator AnimacionEntrada()
    {
        animando = true;

        yield return new WaitForSeconds(esperaInicial);

        yield return StartCoroutine(MoverA(posicionPiso1, escalaPisos));

        pisoActual = 1;
        animando = false;

        ActualizarInteraccionSegunPiso();
    }

    public void IrDerecha()
    {
        if (animando) return;
        if (pisoActual >= 3) return;

        StartCoroutine(CambiarPiso(pisoActual + 1));
    }

    public void IrIzquierda()
    {
        if (animando) return;
        if (pisoActual <= 1) return;

        StartCoroutine(CambiarPiso(pisoActual - 1));
    }

    IEnumerator CambiarPiso(int nuevoPiso)
    {
        animando = true;
        CambiarEstadoFlechas(false);
        CambiarEstadoBotonesNivel(false);

        Vector2 destino = ObtenerPosicionPiso(nuevoPiso);

        yield return StartCoroutine(MoverA(destino, escalaPisos));

        pisoActual = nuevoPiso;
        animando = false;

        ActualizarInteraccionSegunPiso();
    }

    Vector2 ObtenerPosicionPiso(int piso)
    {
        switch (piso)
        {
            case 1: return posicionPiso1;
            case 2: return posicionPiso2;
            case 3: return posicionPiso3;
            default: return posicionPiso1;
        }
    }

    IEnumerator MoverA(Vector2 posicionFinal, Vector3 escalaFinal)
    {
        Vector2 posicionInicial = contenedorCasilleros.anchoredPosition;
        Vector3 escalaInicial = contenedorCasilleros.localScale;

        float tiempo = 0f;

        while (tiempo < duracionMovimiento)
        {
            tiempo += Time.deltaTime;
            float t = tiempo / duracionMovimiento;

            // suavizado
            t = t * t * (3f - 2f * t);

            contenedorCasilleros.anchoredPosition = Vector2.Lerp(posicionInicial, posicionFinal, t);
            contenedorCasilleros.localScale = Vector3.Lerp(escalaInicial, escalaFinal, t);

            yield return null;
        }

        contenedorCasilleros.anchoredPosition = posicionFinal;
        contenedorCasilleros.localScale = escalaFinal;
    }

    void ActualizarInteraccionSegunPiso()
    {
        if (animando)
        {
            CambiarEstadoFlechas(false);
            CambiarEstadoBotonesNivel(false);
            return;
        }

        // Flechas
        if (btnIzquierda != null)
            btnIzquierda.interactable = pisoActual > 1;

        if (btnDerecha != null)
            btnDerecha.interactable = pisoActual < 3;

        // Solo habilitar botones del piso visible
        for (int i = 0; i < botonesNivel.Length; i++)
        {
            if (botonesNivel[i] == null) continue;

            int pisoDelBoton = ObtenerPisoDeIndice(i);
            botonesNivel[i].interactable = (pisoDelBoton == pisoActual);
        }
    }

    void CambiarEstadoFlechas(bool estado)
    {
        if (btnIzquierda != null) btnIzquierda.interactable = estado;
        if (btnDerecha != null) btnDerecha.interactable = estado;
    }

    void CambiarEstadoBotonesNivel(bool estado)
    {
        for (int i = 0; i < botonesNivel.Length; i++)
        {
            if (botonesNivel[i] != null)
                botonesNivel[i].interactable = estado;
        }
    }

    int ObtenerPisoDeIndice(int indice)
    {
        if (indice >= 0 && indice <= 2) return 1; // niveles 1,2,3
        if (indice >= 3 && indice <= 5) return 2; // niveles 4,5,6
        return 3; // niveles 7,8,9
    }

    public void CargarNivel(int indice)
    {
        if (indice < 0 || indice >= escenasNiveles.Length)
        {
            Debug.LogWarning("Índice de nivel fuera de rango: " + indice);
            return;
        }

        if (string.IsNullOrWhiteSpace(escenasNiveles[indice]))
        {
            Debug.LogWarning("No hay escena asignada para el nivel en índice: " + indice);
            return;
        }

        SceneManager.LoadScene(escenasNiveles[indice]);
    }

    public void RegresarAModoJuego()
    {
        SceneManager.LoadScene(escenaRegreso);
    }
}