using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class rotatacamera : MonoBehaviour
{

    public float rotationspeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        transform.Rotate(Vector3.up, horizontalInput * rotationspeed * Time.deltaTime);

    }
}
