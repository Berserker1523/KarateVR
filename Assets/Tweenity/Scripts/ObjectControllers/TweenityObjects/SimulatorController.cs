//
//  SimulatorController.cs
//  Tweenity
//
//  Created by Vivian Gómez.
//  Copyright © 2021 Vivian Gómez - Pablo Figueroa - Universidad de los Andes
//

using System;
using System.Threading.Tasks;
using UnityEngine;

public class SimulatorController : MonoBehaviour
{
    public DialogueViewer dialogueViewer;

    public void ShowReminder1(object countdown, object activeObject)
    {
        GameObject.Find("Reminder1").GetComponent<ReminderController>().MoveOverObject(activeObject.ToString().Trim());
    }

    public void ShowReminder2(object countdown, object activeObject1, object activeObject2, object audioName)
    {
        /*GameObject.Find("Reminder1").GetComponent<ReminderController>().MoveOverObject(activeObject1.ToString().Trim());
        GameObject.Find("Reminder2").GetComponent<ReminderController>().MoveOverObject(activeObject2.ToString().Trim());*/
        Play(audioName.ToString().Trim());
    }

    public int Wait(object time)
    {
        return Convert.ToInt32(time)*1000;
    }

    public void InitializeAudiosDirectory(string dirAudio)
    {
        SimulationController.currentDirectoryAudios = dirAudio;
    }

    public int Play(object audioName)
    {
        return VoiceController.PlayVoice(audioName.ToString());
    }

    public int PlayWithImage(object audioName)
    {
        return VoiceController.PlayVoice(audioName.ToString());
    }

    public void OpenDialogueViewer()
    {
        dialogueViewer.OpenDialogue();
    }

    public void CloseDialogueViewer()
    {
        dialogueViewer.CloseDialogue();
    }
}
