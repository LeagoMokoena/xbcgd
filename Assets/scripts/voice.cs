using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class voice : MonoBehaviour
{
    public Image speakerImage;
    public Text speakerText;
    public Text voiceText;

    private characters speak;
    public characters Speaker
    {
        get { return speak; }
        set { speak = value; speakerImage.sprite = speak.character; speakerText.text = speak.name; }
    }
    public string dialogue
    {
        set { voiceText.text = value; }
    }

    public bool has()
    {
        return speak != null;
    }
    public bool isSpeaking(characters person)
    {
        return speak == person;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
