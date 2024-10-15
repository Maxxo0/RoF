using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{

    private Touch toque;
    private float velocity = 0.5f;
    [SerializeField] float maxCamOnX;

    private void Update()
    {
        MoveCamera();
    }

    public void MoveCamera() 
    {
        if (Input.touchCount > 0)
        {
            toque = Input.GetTouch(0);
            if (toque.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + toque.deltaPosition.x * velocity * Time.deltaTime, transform.position.y, transform.position.z);
                if (transform.position.x > maxCamOnX) transform.position = new Vector3(maxCamOnX, transform.position.y, transform.position.z);
                if (transform.position.x < -maxCamOnX) transform.position = new Vector3(-maxCamOnX, transform.position.y, transform.position.z);
            }
        }
    }
}
