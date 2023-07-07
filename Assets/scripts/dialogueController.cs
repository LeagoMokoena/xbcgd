using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class talkevent : UnityEvent<talk> { }

public class dialogueController : MonoBehaviour
{
    public choice choice;
    public talkevent talkchange;

    public static dialogueController addbutton(Button button, choice _choice, int num)
    {
        int butSpace = -100;
        Button button1 = Instantiate(button);

        button1.transform.SetParent(button.transform.parent);
        button1.transform.localScale = Vector3.one;
        button1.transform.localPosition = new Vector3(0, num * butSpace, 0);
        button1.name = "Choice " + (num + 1);
        button1.gameObject.SetActive(true);

        dialogueController _controller = button1.GetComponent<dialogueController>();
        _controller.choice = _choice;
        return _controller;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (talkchange == null)
        {
            talkchange = new talkevent();
        }

        GetComponent<Button>().GetComponentInChildren<Text>().text = choice.text;
    }

    public void makle()
    {
        talkchange.Invoke(choice._talk_);
    }

    void Update()
    {
        
    }
}
