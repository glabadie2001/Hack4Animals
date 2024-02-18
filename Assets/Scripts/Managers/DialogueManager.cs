using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public RectTransform box;
    public TMP_Text text;
    public Conversation test;

    private const int fillInSpeed = 1;
    private bool anim = false;
    private bool advPhase = false;
    private bool advSentence = false;
    private const float textSpeed = 0.033f;
    private float timer = 0.0f;
    void Start()
    {
        box = GameObject.Find("DialogueManager").GetComponentInChildren<RectTransform>();
        text = GameObject.Find("DialogueManager").GetComponentInChildren<TMP_Text>();
        transformBox(new Vector3(0, -450, 0), new Vector2(1800, 100));
        hide();

        conversation(test);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mPos = Input.mousePosition;
            if(mPos.y < 75)
            {
                if(anim)
                {
                    advSentence = true;
                } else
                {
                    advPhase = true;
                }
            }
        }
    }

    public void transformBox(Vector3 pos, Vector2 size)
    {
        moveBox(pos);
        changeSize(size);
    }

    public void moveBox(Vector3 pos)
    {
        box.position = pos;
        return;
    }

    public void changeSize(Vector2 size)
    {
        box.sizeDelta = size;
        return;
    }

    public void conversation(Conversation convo)
    {
        StartCoroutine(conversationManager(convo));
    }

    private IEnumerator conversationManager(Conversation convo)
    {
        int cLen = convo.length;
        for (int convoPhase = 0; convoPhase < cLen; convoPhase++)
        {
            advPhase = false;
            StartCoroutine(updateText(convo.options[convoPhase]));
            while (!advPhase) yield return false;
        }
        while (!advPhase) yield return false;
        hide();
        yield return true;
    }

    public void hide()
    {
        text.text = string.Empty;
        return;
    }

    private IEnumerator updateText(string str)
    {
        anim = true;
        hide();
        int length = str.Length;
        for (int i = 0; i < str.Length; i += fillInSpeed)
        {
            
            text.text += str.Substring(i, (length < fillInSpeed ? length : fillInSpeed));
            length -= fillInSpeed;
            while (timer < textSpeed)
            {
                timer += Time.deltaTime;
                yield return false;
            }
            timer = 0.0f;
            if(advSentence)
            {
                text.text = str;
                i = str.Length;
            }
            advSentence = false;
        }
        anim = false;
        yield return true;
    }

}