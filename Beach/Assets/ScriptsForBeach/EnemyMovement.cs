using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float topBound = 10;
    public float lowerBound = -10;
    public float speed = 20.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.x > topBound)
        {
            transform.Translate(Vector3.forward * -speed * Time.deltaTime * 2);
            transform.rotation = Quaternion.Euler(transform.rotation.x, -90, transform.rotation.z);
        }
        else if (transform.position.x < lowerBound)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime * 2);
            transform.rotation = Quaternion.Euler(transform.rotation.x, 90, transform.rotation.z);
        }
    }
}









