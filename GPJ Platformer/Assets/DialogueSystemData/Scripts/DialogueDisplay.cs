﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDisplay : MonoBehaviour
{
  public Conversation conversation;

  public GameObject speakerLeft;
  public GameObject speakerRight;

  private SpeakerUI speakerUILeft;
  private SpeakerUI speakerUIRight;

  private int activeLineIndex = 0;
  public AagScriptBase aag;
  public GameObject hint;

  void Start()
  {
      speakerUILeft = speakerLeft.GetComponent<SpeakerUI>();
      speakerUIRight = speakerRight.GetComponent<SpeakerUI>();

      speakerUILeft.Speaker = conversation.speakerLeft;
      speakerUIRight.Speaker = conversation.speakerRight; 
  }

  void Update()
  {
      if (Input.GetKeyDown(KeyCode.R) && aag.onRange ) {
          AdvanceConversation();
          hint.gameObject.SetActive(false);
      }
  }

  void AdvanceConversation()
  {
      if (activeLineIndex < conversation.lines.Length)
      {
          DisplayLine();
          activeLineIndex += 1;
      } else 
      {
          speakerUILeft.Hide();
          speakerUIRight.Hide();
          activeLineIndex = 0;
      }
  }

  void DisplayLine()
  {
      Line line = conversation.lines[activeLineIndex];
      Character character = line.character;

      if (speakerUILeft.SpeakerIs(character))
      {
          SetDialogue(speakerUILeft, speakerUIRight, line.text);
      } else
      {
          SetDialogue(speakerUIRight, speakerUILeft, line.text);
      }
      
  }

  void SetDialogue(SpeakerUI activeSpeakerUI, SpeakerUI inactiveSpeakerUI, string text)
  {
      activeSpeakerUI.Dialogue = text;
      activeSpeakerUI.Show();
      inactiveSpeakerUI.Hide();
  }

}
