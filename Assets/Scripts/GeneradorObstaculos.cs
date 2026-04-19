using UnityEngine;

public class GeneradorObstaculos : MonoBehaviour
{
    public GameObject obstaculoPrefab;
    public float tiempoMinimo = 1.2f;
    public float tiempoMaximo = 2.5f;
    public float posicionX = 12f;
    public float posicionY = 0f;

    private bool activo = true;

    private void Start()
    {
        Invoke(nameof(GenerarObstaculo), 1.5f);
    }

    private void GenerarObstaculo()
    {
        if (!activo) return;
        if (obstaculoPrefab == null) return;

        Vector3 posicion = new Vector3(posicionX, posicionY, 0f);
        Instantiate(obstaculoPrefab, posicion, Quaternion.identity);

        float siguienteTiempo = Random.Range(tiempoMinimo, tiempoMaximo);
        Invoke(nameof(GenerarObstaculo), siguienteTiempo);
    }

    public void Detener()
    {
        activo = false;
        CancelInvoke();
    }
}