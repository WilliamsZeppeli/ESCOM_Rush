using UnityEngine;

public class ObstaculoMovimiento : MonoBehaviour
{
    public float velocidad = 6f;

    private void Update()
    {
        transform.position += Vector3.left * velocidad * Time.deltaTime;

        if (transform.position.x < -20f)
        {
            Destroy(gameObject);
        }
    }
}