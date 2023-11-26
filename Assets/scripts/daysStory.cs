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
        ridUI();

        string t_ex_t = Load();

        List<string> list = story.currentTags;

        if (list.Count > 0)
        {
            t_ex_t = "<b>" + tag[0] + "</b> - " + t_ex_t;
        }

        Text storyte = Instantiate(text) as Text;
        storyte.text = t_ex_t;
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

    void ridUI()
    {
        for(int i = 0;i<this.transform.childCount;i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
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