using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InfoInGame : MonoBehaviour
{
    public Text InfoScore;
    public Text InfoArrows;
    // Start is called before the first frame update


    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Undertale theme");
    }

    // Update is called once per frame
    void Update()
    {
        InfoScore.text = GameStats.score;

        GameStats.setScore(Math.Round((Math.Abs(Time.time))));
        
        InfoArrows.text = GameStats.nbArrows + " / " + GameStats.nbArrowsMax;

    }
}
