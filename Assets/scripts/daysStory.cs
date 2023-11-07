using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using Ink.Runtime;
using UnityEngine.UI;

public class daysStory : MonoBehaviour
{
    public TextAsset textAsset;
    public Story story;
    public Text text;
    public Button button;


    private void Start()
    {
        story = new Story(textAsset.text);

        refresh();
    }

    void refresh()
    {
        Text storyte = Instantiate(text) as Text;
        storyte.text = Load();
        storyte.transform.SetParent(this.transform, false);

        foreach (Choice choice in story.currentChoices)
        {
            Button _butto = Instantiate(button) as Button;
            Text _tex = button.GetComponentInChildren<Text>();
            _tex.text = choice.text;
            _butto.transform.SetParent(this.transform, false);

            _butto.onClick.AddListener(delegate
            {
                dialogueChoice(choice);
            });
        }
    }

    private void dialogueChoice(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        refresh();
    }

    private string Load()
    {
        string _text = "";
        if(story.canContinue)
        {
            _text = story.ContinueMaximally();
        }

        return _text;
    }

}