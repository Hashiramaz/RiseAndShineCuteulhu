using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RotateStars : MonoBehaviour
{
    public Transform leftStar;
    public Transform rightStar;

    public float currentDegreeToMultiply;
    public float maxDegreeToMultiply = 12;

    public float normalOpacity = 1f;
    public float disabledOpacity = 0.6f;

    public Image leftimage;
    public Image rightimage;

    private float timebase = 360 / GameEventSystem.GetCurrentTimeCheckLeft();
    private void Update()
    {
        UpdateStarsRotation();
        //UpdateDegree();
    }

    private void OnEnable()
    {
        GameEventSystem.onGameStart += OnStartGame;
        GameEventSystem.onCheckMatch += OnCheckMAtch;
    }

    private void OnDisable()
    {
        GameEventSystem.onGameStart -= OnStartGame;
        GameEventSystem.onCheckMatch -= OnCheckMAtch;

    }
    public void ResetBaseDegree()
    {
        currentDegreeToMultiply = 360;
    }
    public void UpdateDegree()
    {
        if (GameEventSystem.GetCurrentGameState() != GameState.INGAME)
            return;

        if (currentDegreeToMultiply < maxDegreeToMultiply)
            return;

        currentDegreeToMultiply -= Time.deltaTime * 2;

        if (currentDegreeToMultiply < maxDegreeToMultiply)
            currentDegreeToMultiply = maxDegreeToMultiply;

    }
    public void UpdateStarsRotation()
    {
        if (GameEventSystem.GetCurrentGameState() != GameState.INGAME)
            return;

        leftStar.transform.eulerAngles = new Vector3(1, 1, maxDegreeToMultiply * GameEventSystem.GetCurrentTimeCheckLeft());
        rightStar.transform.eulerAngles = new Vector3(1, 1, -maxDegreeToMultiply * GameEventSystem.GetCurrentTimeCheckLeft());
    }

    public void OnStartGame()
    {
        // ResetBaseDegree();
         SetStartOpacity();
    }

    public void OnCheckMAtch()
    {
            SetStartOpacity();
    }

    public void SetStartOpacity()
    {
        StartCoroutine(StartRoutineOpacity());
    }

    IEnumerator StartRoutineOpacity()
    {
        leftimage.color = new Color(1,1,1,normalOpacity);
        rightimage.color = new Color(1,1,1,normalOpacity);

        yield return new WaitForSeconds(0.5f);

        float alphaToChange = normalOpacity;

        while(alphaToChange > disabledOpacity)
        {   
            alphaToChange -= Time.deltaTime *0.01f;
            leftimage.color = new Color(1,1,1,alphaToChange);
            rightimage.color = new Color(1,1,1,alphaToChange);
        }
    }





}
