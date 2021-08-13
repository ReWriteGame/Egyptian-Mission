using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    public char symbol = ' ';

    [SerializeField] private Text text;

    public void updateSymbol()
    {
        text.text = symbol.ToString();
    }

    public void setRandomSymbol()
    {
        symbol = (char)Random.Range(97, 122);
        updateSymbol();
    }
}
