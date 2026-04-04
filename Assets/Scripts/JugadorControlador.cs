using UnityEngine;

public class JugadorControlador : MonoBehaviour
{
    [Header("Movimiento")]
    public float fuerzaSalto = 10f;

    [Header("Suelo")]
    public Transform puntoSuelo;
    public float radioSuelo = 0.2f;
    public LayerMask capaSuelo;

    private Rigidbody2D rb;
    private bool enSuelo;
    private bool estaVivo = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!estaVivo) return;

        enSuelo = Physics2D.OverlapCircle(puntoSuelo.position, radioSuelo, capaSuelo);

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && enSuelo)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    public void Morir()
    {
        estaVivo = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            Morir();
            FindFirstObjectByType<ControladorJuego>().TerminarJuego();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (puntoSuelo == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(puntoSuelo.position, radioSuelo);
    }
}