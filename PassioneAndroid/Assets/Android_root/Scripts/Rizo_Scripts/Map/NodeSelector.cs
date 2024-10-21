using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSelector : MonoBehaviour
{
    [List][SerializeField] GameObject[] nodeList;
    [SerializeField] bool concreteOption;
    [Dropdown][SerializeField] GameObject selectedNode;
    public void randomNode() 
    {
        if (concreteOption)
        {
            selectedNode.SetActive(true);
        }
        else
        { 
            int randomIndex = Random.Range(0, nodeList.Length);
            selectedNode = nodeList[randomIndex];
            selectedNode.SetActive(true);
        }
        gameObject.GetComponent<NodeRute>().nodeActive = selectedNode;
    }

    public void CompletEvent() 
    {
        selectedNode.SetActive(false);
    }
}
