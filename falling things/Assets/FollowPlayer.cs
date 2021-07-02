using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    private float yoffset;
    private float xoffset;

    public float xBound = 0.13f;
    public float lowyBound = -1f;
    public float upyBound = 0.6f;
    private float z;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        yoffset = this.transform.position.y - player.transform.position.y;
        xoffset = this.transform.position.x - player.transform.position.x;
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {

        float newx = player.transform.position.x + xoffset;
        float newy = player.transform.position.y + yoffset;
        this.transform.position = new Vector3(Mathf.Clamp(newx, -xBound, xBound), Mathf.Clamp(newy, lowyBound, upyBound), z);
    }
}
