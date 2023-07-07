using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public struct choice
{
    [TextArea(2, 5)]
    public string text;
    public talk _talk_;
}

[CreateAssetMenu(fileName = "New question", menuName = "question")]
public class Question : ScriptableObject
{
    [TextArea(2, 5)]
    public string tex;
    public choice[] options;
}
