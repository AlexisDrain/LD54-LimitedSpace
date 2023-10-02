using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PuzzleMorseInput : MonoBehaviour
{
    public UnityEvent onSuccess;
    public UnityEvent onFail;
    public Text letter1;
    public Text letter2;
    public Text letter3;
    public Text letter4;

    private string puzzleText = "";
    private int currentLetters = 0;

    // Update is called once per frame
    public void AddLetter(string newLetter) {

        puzzleText += newLetter;
        currentLetters += 1;
        if (currentLetters == 1) {
            letter1.text = newLetter;
        } else if (currentLetters == 2) {
            letter2.text = newLetter;
        } else if (currentLetters == 3) {
            letter3.text = newLetter;
        } else if (currentLetters == 4) {
            letter4.text = newLetter;
            StartCoroutine("RemoveText");
        }
    }

    public IEnumerator RemoveText() {
        if (puzzleText == "BACK") {
            yield return new WaitForSeconds(1);
            onSuccess.Invoke();
            // scroll down screen using Animator
        } else {
            // play Bad SFX
            yield return new WaitForSeconds(1);
            onFail.Invoke();
            currentLetters = 0;
            puzzleText = "";
            letter1.text = "";
            letter2.text = "";
            letter3.text = "";
            letter4.text = "";
        }
    }
}
