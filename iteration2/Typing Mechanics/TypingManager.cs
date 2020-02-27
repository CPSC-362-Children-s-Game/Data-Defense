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
        words.Add(new Word("added"));
    }

    // Update is called once per frame
    void Update()
    {
        string input = Input.inputString;

        if (input.Equals(""))  //if the user is not typing
        {
            return;   //stops the function 
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
                    Debug.Log("TYPED: " + w.text);  //if the user types the whole word
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
    public string text;
    public UnityEvent onTyped;
    string hasTyped = " ";
    int currentChar = 0;

    public Word(string t)
    {
        text = t
        hasTyped = " ";
        currentChar = 0;
    }

    public bool continueText(char c)
    {
        if(c.Equals(text[currentChar]))
        {
            currentChar++;
            hasTyped = text.Substring(0, currentChar);

            if (currentChar >= text.Length)  //if the user has successfully typed out the entire word
            {
                onTyped.Invoke();
                currentChar = 0;
            }

            return true;
        }
        else
        {
            currentChar = 0;
            hasTyped = " ";
            return false;
        }
    }

    public string getTyped()
    {
        return hasTyped;
    }
}

