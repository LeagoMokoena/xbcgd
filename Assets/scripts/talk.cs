using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public struct line
{
    public characters people;

    [TextArea(2, 5)]
    public string title;
}

[CreateAssetMenu(fileName = "new talk", menuName = "talk")]
public class talk : ScriptableObject
{
    public characters left;
    public characters right;
    public line[] lines;
}
