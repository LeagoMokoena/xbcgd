using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueChoose : MonoBehaviour
{
    public Question que;
    public Text queText;
    public Button Chbutton;

    private List<dialogueController> talkControllers = new List<dialogueController>();

    public void change(Question _question)
    {
        Removed();
        que = _question;
        gameObject.SetActive(true);
        Initialized();
    }

    public void hid(talk _chats)
    {
        Removed();
        gameObject.SetActive(false);
    }

    private void Removed()
    {
        foreach (dialogueController controller in talkControllers)
        {
            Destroy(controller.gameObject);
        }

        talkControllers.Clear();
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Initialized()
    {
        queText.text = que.tex;

        for (int i = 0; i < que.options.Length; i++)
        {
            dialogueController t = dialogueController.addbutton(Chbutton, que.options[i], i);
            talkControllers.Add(t);
        }

        Chbutton.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
