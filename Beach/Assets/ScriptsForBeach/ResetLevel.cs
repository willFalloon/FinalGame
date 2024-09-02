using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour
{
    public bool hitEnemy = false;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.tag == "Enemy")
            {
                hitEnemy = true; 
            }
    }
    // Update is called once per frame
    void Update()
    {
        if (hitEnemy == true)
        {
            RestartScene();
        }
    }
    void RestartScene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }


}