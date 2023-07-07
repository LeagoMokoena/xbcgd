using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[System.Serializable]
public class questionEvent : UnityEvent<Question> { }

public class dialogueDisplay : MonoBehaviour
{
    public talk _talk;
    public talk deflaut;
    public questionEvent QuestionEvent;

    public GameObject left;
    public GameObject right;

    private voice Lspeaker;
    private voice Rspeaker;

    private int activeLine = 0;
    private bool talkstArt = false;

    public void changes(talk _talk_)
    {
        talkstArt = false;
        _talk = _talk_;
        advance();
    }

    // Start is called before the first frame update
    void Start()
    {
        Lspeaker = left.GetComponent<voice>();
        Rspeaker = right.GetComponent<voice>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            advance();
        }
        else if (Input.GetKeyDown("z"))
        {
            endtalk();
            GameObject.FindWithTag("progress").GetComponent<Affection>().ammoi += 2;
        }
        else if (Input.GetKeyDown("t"))
        {
            endtalk();
        }
    }

    private void endtalk()
    {
        _talk = null;
        talkstArt = false;
        Lspeaker.gameObject.SetActive(false);
        Rspeaker.gameObject.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }

    private void Initialize()
    {
        talkstArt = true;
        activeLine = 0;
        Lspeaker.Speaker = _talk.left;
        Rspeaker.Speaker = _talk.right;
    }

    void advance()
    {
        if (_talk == null) return;
        if (!talkstArt)
        {
            Initialize();

        }

        if (activeLine < _talk.lines.Length)
        {
            display();
        }
        else
        {
            Advancetalk();
        }
    }

    void display()
    {
        line l = _talk.lines[activeLine];
        characters pe = l.people;

        if (Lspeaker.isSpeaking(pe))
        {
            setdia(Lspeaker, Rspeaker, l.title);
        }
        else
        {
            setdia(Rspeaker, Lspeaker, l.title);
        }

        activeLine++;

    }

    private void Advancetalk()
    {
        if (_talk.question != null)
            QuestionEvent.Invoke(_talk.question);
        else if (_talk.nwtalk != null)
            changes(_talk.nwtalk);
        else
        {
            endtalk();
        }
    }

    void setdia(voice active, voice inactive, string text)
    {
        active.dialogue = text;
        active.gameObject.SetActive(true);
        inactive.gameObject.SetActive(false);


    }

}

