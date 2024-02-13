using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MaterialColorChanger : MonoBehaviour
{
    // initialize the material
     public Material material;
    // Start is called before the first frame update
    void Start()
    {
        // get the material from the mesh renderer @ index 0
        material = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        // change the color of the material to a random color when the object is collided with wall
        material.color = Random.ColorHSV();
    }
}
