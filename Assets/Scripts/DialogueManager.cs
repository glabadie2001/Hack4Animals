using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public RectTransform box;
    public TMP_Text text;

    private const int fillInSpeed = 1;
    private const float textSpeed = 0.033f;
    private float timer = 0.0f;
    void Start()
    {
        box = GameObject.Find("DialogueManager").GetComponentInChildren<RectTransform>();
        text = GameObject.Find("DialogueManager").GetComponentInChildren<TMP_Text>();
        transformBox(new Vector3(0, -450, 0), new Vector2(1800, 100));
        text.text = string.Empty;
    }


    void Update()
    {
        
    }

    void transformBox(Vector3 pos, Vector2 size)
    {
        moveBox(pos);
        changeSize(size);
    }

    void moveBox(Vector3 pos)
    {
        box.position = pos;
        return;
    }

    void changeSize(Vector2 size)
    {
        box.sizeDelta = size;
        return;
    }

    IEnumerator updateText(string str)
    {
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
        }
        yield return true;
    }
}
