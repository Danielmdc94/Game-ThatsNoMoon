using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileController : MonoBehaviour
{
    private float speed = 15.0f;
    private float scrollSpeed = 5.0f;
    private float zDestroy = 15.0f;
    private float xDestroy = 18.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("PlayerProyectile"))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        else if (gameObject.CompareTag("EnemyProyectile"))
        {
            transform.Translate(Vector3.up * Time.deltaTime * (speed - 5));
            transform.Translate(new Vector3(0, 0, -scrollSpeed) * Time.deltaTime, Space.World);
        }

        if (transform.position.z > zDestroy)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < -zDestroy)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x > xDestroy)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -xDestroy)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        if (gameObject.CompareTag("EnemyProyectile") && other.gameObject.CompareTag("Shield"))
        {
            Destroy(gameObject);
        }
    }
}
