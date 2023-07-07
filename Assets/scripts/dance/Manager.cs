using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public AudioSource mus;
    public bool stplay;
    public arrowScroller scroller;
    public static Manager instance;

    public int current;
    public int scores = 100;
    public int currentScore = 125;
    public int score = 150;

    public int playernum;
    public int multiTrack;
    public int[] mulipilierThres;

    public Text text;
    public Text _text_;

    public float total, normal, good, _perfect, _missed;
    public GameObject screen;
    public Text percent, _normal, _good, _perfect_, misses, rank, final;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        text.text = "Score: 0";
        playernum = 1;
        _text_.text = "Multi: 1";
    }

    // Update is called once per frame
    void Update()
    {
        if(!stplay)
        {
            if (Input.anyKeyDown)
            {
                stplay = true;
                scroller.hsStarted = true;

                mus.Play();
            }
            else
            {
                if(!mus.isPlaying && !screen.activeInHierarchy)
                {
                    screen.SetActive(true);

                    _normal.text = "" + normal;
                    _good.text = good.ToString();
                    _perfect_.text = _perfect_.ToString();
                    misses.text = "" + _missed;

                    float hitTotal = normal + good + _perfect;
                    float hitIDIC = (hitTotal/total) * 100f;

                    percent.text = hitIDIC.ToString("F1") + "%";

                    string val = "F";

                    if(hitIDIC > 40)
                    {
                        val = "D";
                        if(hitIDIC > 55)
                        {
                            val = "C";
                            if(hitIDIC > 70)
                            {
                                val = "B";
                                if(hitIDIC > 85)
                                {
                                    val = "A";
                                    if(hitIDIC > 95)
                                    {
                                        val = "S";
                                    }
                                }
                            }
                        }
                    }
                    
                    rank.text = val;

                    final.text = current.ToString();
                }
            }
        }
    }

    public void Hit()
    {
        if (playernum - 1 < mulipilierThres.Length)
        {
            multiTrack++;
            if (mulipilierThres[playernum - 1] <= multiTrack)
            {
                multiTrack = 0;
                playernum++;
            }
        }
        _text_.text = "Multi: X" + playernum;

        //current += scores * playernum;
        text.text = "Score: " + current;
        
    }

    public void norm()
    {
        current += scores * playernum;
        Hit();

        normal++;
    }

    public void hitted()
    {
        current += scores * playernum;
        Hit();
        good++;
    }

    public void perfect()
    {
        current += scores * playernum;
        Hit();
        _perfect++;
    }

    public void missed()
    {
        playernum = 1;
        multiTrack = 0;
        _text_.text = "Multi: X" + playernum;

        _missed++;
    }
}
