using UnityEngine;

public class JugadorControlador : MonoBehaviour
{
    [Header("Movimiento")]
    public float fuerzaSalto = 10f;

    [Header("Movimiento Horizontal")]
    public float velocidadHorizontal = 6f;
    public float limiteIzquierdo = -7.5f;
    public float limiteDerecho = 7.5f;

    [Header("Suelo")]
    public Transform puntoSuelo;
    public float radioSuelo = 0.2f;
    public LayerMask capaSuelo;

    private Rigidbody2D rb;
    private bool enSuelo;
    private bool estaVivo = true;
    private float inputHorizontal;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!estaVivo) return;

        enSuelo = Physics2D.OverlapCircle(puntoSuelo.position, radioSuelo, capaSuelo);

        inputHorizontal = Input.GetAxisRaw("Horizontal");

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && enSuelo)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if (!estaVivo) return;

        float objetivoX = inputHorizontal * velocidadHorizontal;
        rb.velocity = new Vector2(objetivoX, rb.velocity.y);

        Vector2 posicion = rb.position;
        posicion.x = Mathf.Clamp(posicion.x, limiteIzquierdo, limiteDerecho);
        rb.position = posicion;
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