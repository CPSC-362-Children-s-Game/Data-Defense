using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class FileManager : MonoBehaviour
{
    //[SerializeField] Text txt_randomWord;
    public string[] namesArray;
    string myFilePath, fileName;

    void Start()
    {
        fileName = "words.txt";
        myFilePath = Application.dataPath + "/" + fileName;

        //Initialize namesArray
        namesArray = File.ReadAllLines(myFilePath);
        //DisplayRandomWord();
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.UpArrow))
    //    {
    //        Debug.Log("Reading from file");
    //        ReadFromTheFile();
    //    }
    //}

    //void DisplayRandomWord()
    //{
    //    int randomNumber = Random.Range(0, namesArray.Length);
    //    txt_randomWord.text = namesArray[randomNumber];
    //}

    //public void ReadFromTheFile()
    //{
    //    namesArray = File.ReadAllLines(myFilePath);
    //    DisplayRandomWord();
    //}

    public string wordSetter()
    {
        int random = Random.Range(0, namesArray.Length);
        return namesArray[random];
    }
}


