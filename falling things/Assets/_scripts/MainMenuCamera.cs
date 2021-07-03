using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{

    public Vector3 mmViewPoint;
    public Vector3 htpViewPoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HTP()
    {
        transform.position = htpViewPoint;
    }
    public void MM()
    {
        transform.position = mmViewPoint;
    }
}
