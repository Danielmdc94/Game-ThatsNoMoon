using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject prefabProyectile;
    public GameObject shield;

    private Rigidbody playerRb;
    private GameManager gameManager;

    private float speed = 100000;
    private float zBound = 9;
    private float xBound = 14.5f;
    private float proyectilOffsetX = 1.004f;
    private float proyectileOffsetY = 0.286f;
    private float proyectileOffsetZ = 1.222f;

    private int powerUpValue = 25;

    private bool isGameActive;

    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isGameActive = GameObject.Find("GameManager").GetComponent<GameManager>().isGameActive;

        ConstrainPlayerPosition();

        if (isGameActive == true)
        {
            MovePlayer();


            if (Input.GetKeyDown(KeyCode.Space))
            {
                ShootProyectile();
            }
        }
        else if (isGameActive == false)
        {
            shield.gameObject.SetActive(false);
        }
    }

    //Moves the player based on WASD/arrows keys input
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    //Prevents the player from leaving game area
    void ConstrainPlayerPosition()
    {
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
    }

    //Shoots proyectiles
    void ShootProyectile()
    {
        Instantiate(prefabProyectile, new Vector3(transform.position.x - proyectilOffsetX, transform.position.y + proyectileOffsetY, transform.position.z + proyectileOffsetZ), prefabProyectile.transform.rotation);
        Instantiate(prefabProyectile, new Vector3(transform.position.x - proyectilOffsetX, transform.position.y - proyectileOffsetY, transform.position.z + proyectileOffsetZ), prefabProyectile.transform.rotation);
        Instantiate(prefabProyectile, new Vector3(transform.position.x + proyectilOffsetX, transform.position.y + proyectileOffsetY, transform.position.z + proyectileOffsetZ), prefabProyectile.transform.rotation);
        Instantiate(prefabProyectile, new Vector3(transform.position.x + proyectilOffsetX, transform.position.y - proyectileOffsetY, transform.position.z + proyectileOffsetZ), prefabProyectile.transform.rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (shield.activeSelf == false && collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.GameOver();
        }
        else if (shield.activeSelf == true && collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }

            if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameManager.GameOver();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            gameManager.UpdateScore(powerUpValue);
            shield.SetActive(true);
            StartCoroutine(PowerUpCountDownRoutine());



        }
        if (shield.activeSelf == false)
        {
            if (other.gameObject.CompareTag("EnemyProyectile"))
            {
                Destroy(other.gameObject);
                gameManager.GameOver();
            }
        }
    }
    IEnumerator PowerUpCountDownRoutine()
    {
        yield return new WaitForSeconds(7);
        shield.gameObject.SetActive(false);
    }
}
