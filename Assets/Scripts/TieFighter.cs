using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieFighter : MonoBehaviour
{
    private GameManager gameManager;

    private Rigidbody tieRb;

    private float speed = 30000;
    private float zDestroy = -15.0f;
    private int pointValue = 25;
    private float proyectileOffsetX = 0.071343f;
    private float proyectileOffsetY = 0.189f;

    public GameObject prefabProyectile;
    private float shootDelay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        tieRb = gameObject.GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating("ShootProyectile", 0, shootDelay);
    }

    // Update is called once per frame
    void Update()
    {
        tieRb.AddForce(Vector3.forward * -speed);

        if (transform.position.z < zDestroy)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerProyectile"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
        }
    }

    void ShootProyectile()
    {
        Instantiate(prefabProyectile, new Vector3(transform.position.x + proyectileOffsetX, transform.position.y - proyectileOffsetY, transform.position.z), prefabProyectile.transform.rotation);
        Instantiate(prefabProyectile, new Vector3(transform.position.x - proyectileOffsetX, transform.position.y - proyectileOffsetY, transform.position.z), prefabProyectile.transform.rotation);
    }
}
