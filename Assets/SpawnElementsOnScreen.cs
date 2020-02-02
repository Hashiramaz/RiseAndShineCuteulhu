using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnElementsOnScreen : MonoBehaviour
{
    public SpawnArea comboAreaToSpawn;
    public SpawnArea messageAreaToSpawn1;
    public SpawnArea messageAreaToSpawn2;


    public ComboObjectController comboObjectPrefab;
    public MessageObjectController messageObjectPrefab;

    private void OnEnable() {
        
        GameEventSystem.onGreatCombo += OnGreatCombo;

        GameEventSystem.onReceiveMessageValidEvent += OnValidMessageReceived;
    }

    private void OnDisable() {
        GameEventSystem.onGreatCombo -= OnGreatCombo;
        GameEventSystem.onReceiveMessageValidEvent -= OnValidMessageReceived;
        
    }
    public void SpawnComboObjet(string combo)
    {
        var obj = Instantiate(comboObjectPrefab,comboAreaToSpawn.GetRandomPoint(),transform.rotation);
            obj.SetcomboText(combo);
    }


    public void OnGreatCombo()
    {
        SpawnComboObjet(GameEventSystem.GetCurrentCombo().ToString());
    }

    public void OnValidMessageReceived(string user, string message)
    {
            var obj = Instantiate(messageObjectPrefab,GetRandomMessagePoint(),transform.rotation);
            obj.SetMessageText(message);
            obj.SetUserText(user);
    }

    public Vector3 GetRandomMessagePoint()
    {
        int randomindex = Random.Range(0,2);

        if(randomindex == 1)
            return messageAreaToSpawn1.GetRandomPoint();
        else
            return messageAreaToSpawn2.GetRandomPoint();
        
            
        
    }


    
}
