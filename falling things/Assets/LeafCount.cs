using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeafCount : MonoBehaviour
{
    GameController gc;
    Text t;
    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        t = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        t.text = gc.totalFallenLeaves.ToString();
    }
}
