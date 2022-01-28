using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollDown : MonoBehaviour
{
    private float scrollSpeed = 5.0f;
    private float zDestroy = 15.0f;

    private Vector3 startPos;
    private float repeatLength;

    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("Background"))
        {
            startPos = transform.position;
            repeatLength = 48;
        }
    }

    // Update is called once per frame
    void Update()
    {
        isGameActive = FindObjectOfType<GameManager>().isGameActive;

        if (isGameActive == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * scrollSpeed);

            if (gameObject.CompareTag("Background"))
            {
                if (transform.position.z < startPos.z - repeatLength)
                {
                    transform.position = startPos;
                }
            }
            else if (gameObject.CompareTag("Background") == false)
            {
                if (transform.position.z < -zDestroy)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
