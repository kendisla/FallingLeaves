using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLeaves : MonoBehaviour
{
    GameController gc;
    SpriteRenderer sr;

    public GameObject leafPrefab;

    public int droppedLeaves = 0;

    Sprite[] ls = new Sprite[3];


    public float[] range;

    PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Spawn()
    {
        float wait = Random.Range(range[0], range[1]);
        int leaf = Random.Range(0,2);
        Debug.Log(gameObject.name + " waiting for " + wait + " seconds before spawning");
        yield return new WaitForSeconds(wait);
        GameObject l = Instantiate(leafPrefab, new Vector3(Random.Range(-1.95f, 1.95f), 0.6f), Quaternion.identity);
        l.GetComponent<SpriteRenderer>().sprite = ls[leaf];
        Destroy(l, 2f);
        if (!pc.dead)
        {
            droppedLeaves++;
            StartCoroutine(Spawn());
        }
    }

    public void UpdateSeason(Sprite newTree, Sprite nl1, Sprite nl2, Sprite nl3, float[] newRange)
    {
        sr.sprite = newTree;
        ls[0] = nl1;
        ls[1] = nl2;
        ls[2] = nl3;
        range = newRange;
        GameObject[] oldleaves =GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject l in oldleaves)
        {
            Destroy(l);
        }
    }

    public void Reset()
    {
        droppedLeaves = 0;
        StopAllCoroutines();
    }
}
