using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Sprite left;
    public Sprite right;
    public Sprite jump;
    public Sprite land;

    public bool dead = true;
    public float speed = 5f;
    public float jumpForce = 7f;
    bool landing;
    Rigidbody2D rb;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!dead)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.AddForce(Vector2.up * jumpForce);
                if (!landing)
                {
                    sr.sprite = jump;
                }

            }
            else
            {
                if (!landing)
                {
                    sr.sprite = left;
                }
            }


            if (Input.GetKey(KeyCode.LeftArrow))
            {
                sr.flipX = false;
                rb.AddForce(Vector2.left * speed);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                sr.flipX = true;
                rb.AddForce(Vector2.right * speed);
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        StartCoroutine(Landing());
        if (other.collider.tag.Equals("enemy"))
        {
            Die();
        }
    }

    public IEnumerator Landing() 
    {
        landing = true;
        sr.sprite = land;
        yield return new WaitForSeconds(0.5f);
        landing = false;
    }
    public void Die() 
    {
        dead = true;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().EndGame();
    }
    public void Restart()
    {
        dead = false;
    }
}
