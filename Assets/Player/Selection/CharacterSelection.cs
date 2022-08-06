using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] GameObject[] players;
    [SerializeField] Animator anim;
    [SerializeField] Anvil anvil;
    [SerializeField] GameObject fuelUI;
    [SerializeField] CameraController[] cc;
    
    public void Chosen(int num){
        var temp = Instantiate(players[num], new Vector3(0, 0, 0), Quaternion.identity);
        Movement mm = temp.GetComponent<Movement>();
        Drill d = temp.transform.GetChild(0).GetComponent<Drill>();
        cc[0].player = temp.transform;
        //cc[1].player = temp.transform;
        anvil.SetVariables(mm, d);
        
        fuelUI.SetActive(true);
    }

    public void OnClick(int num){
        switch(num){
            case 0: anim.SetTrigger("BM"); break;
            case 1: anim.SetTrigger("BW"); break;
            case 2: anim.SetTrigger("WM"); break;
            case 3: anim.SetTrigger("WW"); break;
        }
    }
}
