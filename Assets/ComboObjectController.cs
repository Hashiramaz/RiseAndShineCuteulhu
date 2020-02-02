using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;
using TMPro;

public class ComboObjectController : MonoBehaviour
{
    public LeanWindow objectWindow;
    public TextMeshPro textMesh;

    public float timeOnScreen = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(objectRoutine());
    }

    public void SetcomboText(string text)
    {
        textMesh.text = text;
    }
    IEnumerator objectRoutine(){
        objectWindow.TurnOn();
        yield return new WaitForSeconds(timeOnScreen);
        objectWindow.TurnOff();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    
}
