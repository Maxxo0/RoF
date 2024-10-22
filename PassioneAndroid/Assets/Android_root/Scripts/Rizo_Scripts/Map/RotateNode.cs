using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateNode : MonoBehaviour
{
    // Start is called before the first frame update
    public float amplitude = 0.2f;  // La cantidad de desplazamiento vertical (amplitud)
    public float frequency = 1f;    // La velocidad de oscilación (frecuencia)
    public bool stop=true;
    private Vector3 startPos;       // La posición inicial del objeto
    private void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        if (stop) return;
        // Calcula el nuevo desplazamiento en el eje Y usando Mathf.Sin
        float newY = Mathf.Sin(Time.time * frequency) * amplitude;

        // Aplica el desplazamiento vertical manteniendo las posiciones X y Z originales
        transform.position = new Vector3(startPos.x, startPos.y + newY + amplitude, startPos.z);
    }
}
