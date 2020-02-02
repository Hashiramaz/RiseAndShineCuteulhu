using System.Collections;
using System.Collections.Generic;
using Lean.Gui;
using TMPro;
using UnityEngine;

public class MessageObjectController : MonoBehaviour
{
    public LeanWindow objectWindow;
    public TextMeshPro userTextMesh;
    public TextMeshPro messageTextMesh;
    

    public float timeOnScreen = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(objectRoutine());
    }

    public void SetUserText(string text)
    {
        userTextMesh.text = text;
    }
    public void SetMessageText(string text)
    {
        messageTextMesh.text = text;
    }
    IEnumerator objectRoutine(){
        objectWindow.TurnOn();
        yield return new WaitForSeconds(timeOnScreen);
        objectWindow.TurnOff();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
