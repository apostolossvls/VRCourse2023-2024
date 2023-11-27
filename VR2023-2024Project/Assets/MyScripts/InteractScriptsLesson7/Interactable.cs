using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Version 1.2
//interactor calls and receives from an IInteractable
//anything we want to be interactable has to implement IInteractable
public interface IInteractable
{
    //abstract OnInteract. It gets an Interactor so that it may return to it.
    void OnInteract(Interactor interactor);

    //abstract. Called when interaction had started and now ends (Forced or not).
    void OnEndInteract();

    //abstract. Called when object gets selected and ready to interact.
    //Can be used to indicate selection.
    void OnReadyInteract();

    //abstract. Called when object gets deselected from interacting.
    //Can be used to remove select indication.
    void OnAbortInteract();
}
