using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public PlayerStartBar playerStartBar;

    [Header("事件监听")]
    public CharacterEventSO bloodEvent;
    
    private void OnEnable(){
        bloodEvent.OnEventRaised += OnBloodEvent;
    }

    private void DisEnable(){
        bloodEvent.OnEventRaised -= OnBloodEvent;
    }

    private void OnBloodEvent(Character character)
    {
        var persentage = character.currentblood / character.maxblood;
        playerStartBar.OnBloodChange(persentage);
    }
}
