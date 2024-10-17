using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSpawn : MonoBehaviour
{
    [SerializeField] float rangeSpawn;
    [SerializeField] GameObject Node;

    private void Start()
    {
        ResetPosition();
    }
    public void ResetPosition() 
    {
        Node.transform.position = new Vector3(transform.position.x + Random.Range(-rangeSpawn, rangeSpawn),
        transform.position.y,
        transform.position.z + Random.Range(-rangeSpawn, rangeSpawn));
        Node.GetComponent<NodeSelector>().randomNode();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeSpawn);
    }
}
