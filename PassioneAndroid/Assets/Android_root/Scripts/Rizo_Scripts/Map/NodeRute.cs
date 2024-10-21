using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NodeRute : MonoBehaviour
{
    [SerializeField] GameObject[] nodos_a_desactivar;
    [SerializeField] GameObject[] nodos_a_activar;
    public GameObject nodeActive;
    public void NextFase()
    {
        Desactive();
        foreach (GameObject obj in nodos_a_desactivar)
        {
            obj.GetComponent<NodeRute>().Desactive();
        }
        foreach (GameObject obj in nodos_a_activar) 
        {
            obj.GetComponent<NodeRute>().Active();
        }
    }

    public void Active()
    { 
        gameObject.GetComponent<SphereCollider>().enabled = true;
        nodeActive.GetComponent<RotateNode>().stop = false;
    }
    public void Desactive() 
    {
        gameObject.GetComponent<SphereCollider>().enabled = false;
        nodeActive.GetComponent<RotateNode>().stop = true;
        nodeActive.SetActive(false);
    }
}
