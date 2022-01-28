using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private GameObject powerUp;
    // Start is called before the first frame update
    void Start()
    {
        powerUp = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        powerUp.transform.Rotate(new Vector3(0, 60, 0) * Time.deltaTime, Space.World);
    }
}
