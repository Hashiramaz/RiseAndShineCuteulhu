using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SigilAnimationController : MonoBehaviour
{
    public Sprite[] animationList;


    public Image spriteImageUI;

    public Animator amin;

    private void OnEnable() {
     GameEventSystem.onGreatCombo += OnGreatCombo;
     GameEventSystem.onBadCombo += OnBadCombo;
     GameEventSystem.onGameStart += OnPrepareGame;   
    }

    private void OnDisable() {
     GameEventSystem.onGreatCombo -= OnGreatCombo;
     GameEventSystem.onBadCombo -= OnBadCombo;
     GameEventSystem.onGameStart -= OnPrepareGame;   
        
    }

    

    public void UpdateCurrentSpriteAnimation()
    {
        SetCurrentSpriteAnimation(animationList[(int)GameEventSystem.GetCurrentLife()]);
        SetAnimationSpeed((int)GameEventSystem.GetCurrentLife());
    }

    public void SetCurrentSpriteAnimation(Sprite _sprite)
    {
        spriteImageUI.sprite = _sprite;
    }

    public void SetAnimationSpeed(int level)
    {   float _speed =0;
        if(level == 0)
        {
            _speed = 0.2f;
        }else if(level == 1)
        {
            _speed = 0.3f;
        }else if(level == 2)
        {
            _speed = 0.4f;
        }else if(level == 3)
        {
            _speed = 0.6f;
        }else if(level == 4)
        {
            _speed = 0.8f;
        }else if(level == 5)
        {
            _speed = 1.1f;
        }else if(level == 6)
        {   
            _speed = 1.4f;
        }else if(level == 7)
        {
            _speed = 1.6f;
        }else if(level == 8)
        {
            _speed = 2f;
        }else if(level == 9)
        {
            _speed = 2.5f;
        }else if(level == 10)
        {
            _speed = 0.15f;
        }


        amin.speed = _speed;
    }

    public void OnPrepareGame(){
        UpdateCurrentSpriteAnimation();
    }

    public void OnGreatCombo(){
        UpdateCurrentSpriteAnimation();
    }

    public void OnBadCombo(){   
        UpdateCurrentSpriteAnimation();

    }
}
