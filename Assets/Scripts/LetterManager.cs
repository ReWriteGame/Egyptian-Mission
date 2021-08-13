using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class LetterManager : MonoBehaviour
{
    [SerializeField] private Text wordField;
    [SerializeField] private List<Letter> letters;
    [SerializeField] private List<string> words;

    private string currentWord;

    public UnityEvent onLoseEvent;
    public UnityEvent onWinEvent;

    public void checkCurrentWords()
    {
        StartCoroutine(checkCurrentWordsCor());
    }
    IEnumerator checkCurrentWordsCor()
    {
        print(43);
        yield return new WaitForSeconds(.3f);
        for (int i = 0; i < currentWord.Length; i++)
            if (letters[i] == null)
                onLoseEvent?.Invoke();


        for (int i = currentWord.Length; i < letters.Count && letters[i] == null; i++)
            if (i == letters.Count - 1)
                onWinEvent?.Invoke();

        yield break;
    }

    private void Start()
    {
        foreach (Letter letter in letters)
            letter.setRandomSymbol();

        currentWord = words[Random.Range(0, words.Count)];
        wordField.text = currentWord;

        for (int i = 0; i < currentWord.Length; i++)
        {
            letters[i].symbol = currentWord[i];
            letters[i].updateSymbol();
        }
        
    }

}
