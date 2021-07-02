using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    AudioSource collision;
    // Start is called before the first frame update
    void Start()
    {
        collision = GameObject.FindGameObjectWithTag("collision").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        collision.Play();
    }
}
