using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesintegrateEffect : MonoBehaviour
{
    public Material material;        // El material con el shader de desintegración
    public float desintegrateDuration = 2f;  // Tiempo en segundos para la desintegración (en este caso, 2 segundos)

    private float dissolveAmount = 0f;  // El valor que controla la desintegración
    private bool isDesintegrating = false;

    void Start()
    {
        // Asegúrate de que el material está correctamente asignado
        if (material == null)
        {
            material = GetComponent<Renderer>().material;
        }
    }




    public void die()
    {
        StartCoroutine(DesintegrateOverTime());
    }

    IEnumerator DesintegrateOverTime()
    {
        isDesintegrating = true;
        float elapsedTime = 0f;

        // Animamos el valor de "DissolveAmount" de 0 a 1 en desintegrateDuration segundos
        while (elapsedTime < desintegrateDuration)
        {
            elapsedTime += Time.deltaTime;
            dissolveAmount = Mathf.Clamp01(elapsedTime / desintegrateDuration);

            // Asignamos el valor al material (asegúrate que el nombre del parámetro coincida con el del shader)
            material.SetFloat("_DissolveAmount", dissolveAmount);

            yield return null;  // Esperar un frame
        }

        // Al final de la animación, aseguramos que el objeto esté completamente desintegrado
        material.SetFloat("_DissolveAmount", 1f);
    }
}

