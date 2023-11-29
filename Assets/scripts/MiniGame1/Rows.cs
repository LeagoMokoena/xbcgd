using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rows : MonoBehaviour
{
    public Tiles[] tiles { get; private set; }

    public string Word
    {
        get
        {
            string word = "";

            for (int i = 0; i < tiles.Length; i++)
            {
                word += tiles[i].letter;
            }

            return word;
        }
    }

    private void Awake()
    {
        tiles = GetComponentsInChildren<Tiles>();
    }

}