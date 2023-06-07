using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueDisplay : MonoBehaviour
{
    public talk _talk;

    public GameObject left;
    public GameObject right;

    private voice Lspeaker;
    private voice Rspeaker;

    private int activeLine = 0;

    // Start is called before the first frame update
    void Start()
    {
        Lspeaker = left.GetComponent<voice>();
        Rspeaker = right.GetComponent<voice>();

        Lspeaker.Speaker = _talk.left;
        Rspeaker.Speaker = _talk.right;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            advance();
        }
    }

    void advance()
    {
        if (activeLine < _talk.lines.Length)
        {
            display();
            activeLine++;
        }
        else
        {
            Lspeaker.gameObject.SetActive(false);
            Rspeaker.gameObject.SetActive(false);
            activeLine = 0;
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

    }

    void setdia(voice active, voice inactive, string text)
    {
        active.dialogue = text;
        active.gameObject.SetActive(true);
        inactive.gameObject.SetActive(false);
    }
}

