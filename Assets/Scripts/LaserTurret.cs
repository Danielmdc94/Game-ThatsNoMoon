using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : MonoBehaviour
{
    private GameManager gameManager;

    private Rigidbody turretRb;
    private Transform targetPlayer;

    private int pointValue = 50;

    public GameObject cannon1;
    public GameObject cannon2;
    public GameObject prefabProyectile;
    private float shootDelay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        turretRb = gameObject.GetComponent<Rigidbody>();
        targetPlayer = FindObjectOfType<PlayerController>().gameObject.transform;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        InvokeRepeating("ShootProyectile", 0, shootDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive == true)
        {
            Vector3 relativePos = targetPlayer.position - transform.position;
            Quaternion toRotation = Quaternion.LookRotation(relativePos);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 1 * Time.deltaTime);
        }

    }

    void ShootProyectile()
    {
        if(gameManager.isGameActive == true)
        {
            Instantiate(prefabProyectile, new Vector3(cannon1.transform.position.x, cannon1.transform.position.y, cannon1.transform.position.z), cannon1.transform.rotation);
            Instantiate(prefabProyectile, new Vector3(cannon2.transform.position.x, cannon2.transform.position.y, cannon2.transform.position.z), cannon2.transform.rotation);
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
