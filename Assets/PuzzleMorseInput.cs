using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleMorseInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        GetComponent<Text>().text = "";
    }

    // Update is called once per frame
    public void AddLetter(string newLetter) {
        if (GetComponent<Text>().text.Length == 4) {
            return; // incase we spam a keyboard button after 4 characters
        }

        GetComponent<Text>().text += newLetter.ToUpper();
        if(GetComponent<Text>().text.Length == 4) {
            StartCoroutine("RemoveText");
        }
             
    }

    public IEnumerator RemoveText() {
        if (GetComponent<Text>().text == "BACK") {
            yield return new WaitForSeconds(1);
            // play good SFX
            print("Good result");
            // scroll down screen using Animator
        } else {
            // play Bad SFX
            yield return new WaitForSeconds(1);
            print("bad result");
            GetComponent<Text>().text = "";
        }
    }
}
