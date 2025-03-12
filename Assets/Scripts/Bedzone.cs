using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bedzone : MonoBehaviour, IHealDropZone
{
    public void OnMonsDroptoZone(MonsterCtrl monsterCtrl)
    {
        //monsterCtrl.transform.position = transform.position;
        monsterCtrl.transform.position = new Vector3(transform.position.x, transform.position.y);
        //transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
        //Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        Debug.Log("DroptoBed");
    }
}
