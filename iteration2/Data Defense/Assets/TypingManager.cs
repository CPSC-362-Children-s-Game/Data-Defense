using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TypingManager : MonoBehaviour
{
    public List<Word> words;
    public Text display;

    private void Start()
    {
        words.Add(new Word("cactus"));
        words.Add(new Word("turkey"));
        words.Add(new Word("monkey"));
        words.Add(new Word("toothbrush"));
        words.Add(new Word("brain"));
        words.Add(new Word("basketball"));
        words.Add(new Word("bear"));
        words.Add(new Word("tiger"));
        words.Add(new Word("gorilla"));
    }

    // Update is called once per frame
    void Update()
    {
        string input = Input.inputString.ToLower();
        if (input.Equals(""))           //if we are no typing
        {
            return;  //Stops this function here
        }
        char c = input[0];
        string typing = "";

        for (int i = 0; i < words.Count; i++)
        {
            Word w = words[i];
            if (w.continueText(c))
            {
                string typed = w.getTyped();
                typing += typed + "\n";
                if (typed.Equals(w.text))
                {
                    Debug.Log("Typed: " + w.text);
                    words.Remove(w);
                    break;
                }
            }
        }
        display.text = typing;
    }
}

[System.Serializable]
public class Word
{
    public UnityEvent onTyped;
    public string text;
    string hasTyped = " ";
    int curChar = 0;

    public Word(string t)
    {
        text = t;
        hasTyped = " ";
        curChar = 0;
    }

    public bool continueText(char c)
    {
        if (c.Equals(text[curChar]))
        {
            curChar++;
            hasTyped = text.Substring(0, curChar);

            if (curChar >= text.Length)
            {
                //onTyped.Invoke();
                curChar = 0;
            }
            return true;
        }
        else
        {
            hasTyped = " ";
            curChar = 0;
            return false;
        }
    }

    public string getTyped()
    {
        return hasTyped;
    }
}