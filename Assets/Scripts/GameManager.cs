using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    public bool enPausa = false;

    void Awake()
    {
        instancia = this;
    }

    public void Pausar()
    {
        enPausa = true;
        Time.timeScale = 0f;
    }

    public void Reanudar()
    {
        enPausa = false;
        Time.timeScale = 1f;
    }
}