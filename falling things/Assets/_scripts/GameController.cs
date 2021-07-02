using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int totalFallenLeaves = 0;
    int season = 0;
    public SpawnLeaves tree1;
    public SpawnLeaves tree2;

    public float[] timeRange = new float[2];

    public Sprite spring;
    public Sprite summer;
    public Sprite fall;

    public Sprite cb1;
    public Sprite cb2;
    public Sprite cb3;

    public Sprite sl1;
    public Sprite sl2;
    public Sprite sl3;

    public Sprite fl1;
    public Sprite fl2;
    public Sprite fl3;

    public int highscore;
    public int currentscore;

    public Canvas persistent;
    public Canvas udied;

    // Start is called before the first frame update
    void Start()
    {
        season = 0;
        timeRange[0] = 3f;
        timeRange[1] = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        totalFallenLeaves = tree1.droppedLeaves + tree2.droppedLeaves;
        if(totalFallenLeaves > 20 && season == 0)
        {
            season = 1;
            timeRange[0] = 1.5f;
            timeRange[1] = 3f;
            tree1.UpdateSeason(summer, sl1, sl2, sl3, timeRange);
            tree2.UpdateSeason(summer, sl1, sl2, sl3, timeRange);
        }
        else if(totalFallenLeaves > 50 && season == 1)
        {
            season = 2;
            timeRange[0] = 0.5f;
            timeRange[1] = 1.5f;
            tree1.UpdateSeason(fall, fl1, fl2, fl3, timeRange);
            tree2.UpdateSeason(fall, fl1, fl2, fl3, timeRange);
        }
    }

    public void StartGame()
    {
        tree1.UpdateSeason(spring, cb1, cb2, cb3, timeRange);
        tree2.UpdateSeason(spring, cb1, cb2, cb3, timeRange);

        StartCoroutine(tree1.Spawn());
        StartCoroutine(tree2.Spawn());
    }

    public void Reset()
    {

        season = 0;
        timeRange[0] = 3f;
        timeRange[1] = 6f;
        tree1.Reset();
        tree2.Reset();
        persistent.enabled = true;
        udied.enabled = false;
    }

    public void EndGame()
    {
        StopAllCoroutines();

        currentscore = totalFallenLeaves;

        if(currentscore > highscore)
        {
            highscore = currentscore;
        }

        persistent.enabled = false;
        udied.enabled = true;
    }

}
