using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NodeRute : MonoBehaviour
{
    [SerializeField] bool isNodeTappeable=false;
    [SerializeField] GameObject[] nodos_a_desactivar;
    [SerializeField] GameObject[] nodos_a_activar;
    public GameObject nodeActive;
    public void NextFase()
    {
        if (!isNodeTappeable) return;
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
        isNodeTappeable = true;
        gameObject.GetComponent<SphereCollider>().enabled = true;
        nodeActive.GetComponent<RotateNode>().stop = false;
    }
    public void Desactive() 
    {
        
        isNodeTappeable = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;
        nodeActive.GetComponent<RotateNode>().stop = true;
        SceneManager.Instance.SelectLevel();
        nodeActive.SetActive(false);
    }
}
