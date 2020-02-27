/*This is a basic typing mechanic for the game Data Defense. This allows the user to be able to type the word
 that the picture displays on the screen. If the user gets the word correct, the user will be able to inflict
 damage onto the opponent. If guessed wrong or typed incorrectly, the user will take damage.*/
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
        text = t;
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
        else                                //if the user has unsuccessfully typed out the entire word
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

