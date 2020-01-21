using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalpoint;
    private float powerupStrength = 15.0f;
    public float speed = 5.0f;
    public bool haspowerup = false;
    public GameObject PowerupIndicator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalpoint = GameObject.Find("focal point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalpoint.transform.forward * forwardInput * speed);
        PowerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("powerup"))
        {
            haspowerup = true;
            PowerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
     yield return new WaitForSeconds(7);
     haspowerup = false;
     PowerupIndicator.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy") && haspowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            
            Debug.Log("collided with: " + collision.gameObject.name + "with powerup set to " + haspowerup);
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength,ForceMode.Impulse);
        }
        
        
          
        
    }
}
