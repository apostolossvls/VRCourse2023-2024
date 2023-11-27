using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //we will use advanced UI text elements
using UnityEngine.UI; //default UI text elements

//Version 1.2
//interactor helper that return an output to the User using UI elements
//this supports only showing a message on a text UI element
public class InteractorUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText; //text that displayes a message
    //comment out above line and use the one below if you are NOT using TextMeshPro;
    //[SerializeField] private Text messageText;

    void Start(){
        HideTextMessage(); //reset and hide

        //console warning if variables doesn't have a reference
        //we may put if statements on methods but this will fill up the code without practical use
        //...other that we forgot to assign these. We rimind it on the Start method.
        if (messageText == null) Debug.LogWarning("InteractorUI: messageText was not set.");
    }
    
    //public method that shows a given message on a UI text element 
    public void ShowTextMessage(string message){
        if (messageText==null){ //check if not null
            Debug.LogWarning("ShowTextMessage (method): messageText was not found.");
            return;
        }
        messageText.text = message; //set text of ui text element
        messageText.gameObject.SetActive(true); //enable/show text
    }

    //public method that hides UI text element
    public void HideTextMessage(){
        if (messageText == null){ //check if not null
            Debug.LogWarning("HideTextMessage (method): messageText was not found.");
            return;
        }
        messageText.text = ""; //empty text for safety
        messageText.gameObject.SetActive(false); //disable/hide text
    }
}
