using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class daysStory : MonoBehaviour
{
    public TextAsset inkJSONAsset;
    private Story story;
    public Button buttonPrefab;
    public GameObject player;
    
    void Start()
    {
        story = new Story(inkJSONAsset.text);

        refresh();

    }

    void refresh()
    {
       
        clearUI();

      
        GameObject newGameObject = new GameObject("TextChunk");
      
        newGameObject.transform.SetParent(this.transform, false);

        Text newTextObject = newGameObject.AddComponent<Text>();
       
        newTextObject.fontSize = 30;

     
        string text = getNextStoryBlock();
        if(text == "")
        {
            slesrt();

        }

        List<string> tags = story.currentTags;

      
        if (tags.Count > 0)
        {
            newTextObject.text = "<color=grey>" + tags[0] + "</color> – " + text;
        }
        else
        {
            newTextObject.text = text;
        }


        newTextObject.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;

        foreach (Choice choice in story.currentChoices)
        {
            Button choiceButton = Instantiate(buttonPrefab) as Button;
            choiceButton.transform.SetParent(this.transform, false);

     
            Text choiceText = choiceButton.GetComponentInChildren<Text>();
            choiceText.text = " " + (choice.index + 1) + ". " + choice.text;

        
            choiceButton.onClick.AddListener(delegate {
                OnClickChoiceButton(choice);
            });

        }

        //StartCoroutine(select());
    }

 
    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        refresh();
    }


    void clearUI()
    {
        int childCount = this.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            GameObject.Destroy(this.transform.GetChild(i).gameObject);
        }
    }



    string getNextStoryBlock()
    {
        string text = "";

        if (story.canContinue)
        {
            text = story.ContinueMaximally();
        }
        else
        {
            StartCoroutine(select());
        }
       

        return text;
    }

    private IEnumerator select()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        this.gameObject.SetActive(false);
       player.SetActive(true);

    }

    void slesrt()
    {
        player.GetComponent<controller>().num += 2;
        this.gameObject.SetActive(false);
        player.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}