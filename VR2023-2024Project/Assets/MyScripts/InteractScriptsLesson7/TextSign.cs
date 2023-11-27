using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Version 1.2
//A class of a sign, it contains a message for display
public class TextSign : MonoBehaviour, IInteractable
{
	[SerializeField] private GameObject indicator;
    [TextArea(3,10)]
    public string text;

    public void OnInteract(Interactor interactor){
		indicator.SetActive(false); //hide
        //call interactor's public method ReceiveInteract
        //...with override method that gets a string as a parameter
        interactor.ReceiveInteract(text);
    }	
	
	//unimplemented Methods
    public void OnEndInteract()
    {
    }

    public void OnAbortInteract()
    {
		indicator.SetActive(false); //hide
    }

    public void OnReadyInteract()
    {
		indicator.SetActive(true); //show
    }
}
