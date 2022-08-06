using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Anvil : MonoBehaviour
{
    private Movement mm;
    private Drill d;
    private int moneyAmt;

    [SerializeField] GameObject store;
    [SerializeField] int[] costs;
    [SerializeField] int[] levels;
    [SerializeField] TMP_Text[] levelT;
    [SerializeField] TMP_Text[] costT;
    [SerializeField] TMP_Text money;


    void Start(){
        mm = FindObjectOfType<Movement>();
        d = FindObjectOfType<Drill>();
    }

    void Update(){
        if(d) d.damageLevel = levels[0];
        if(d) d.fuelLevel = levels[1];
        if(mm) mm.speedLevel = levels[2];

        int.TryParse(money.text, out moneyAmt);
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            store.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.CompareTag("Player")){
            store.SetActive(false);
            d.Refill();
        }
    }

    public void Upgrade(int num){
        if(moneyAmt >= costs[num]){
            moneyAmt -= costs[num];
            money.text = moneyAmt.ToString();

            costs[num] = (int)(costs[num] * 1.5f);
            levels[num] += 1;
            levelT[num].text = levels[num].ToString();
            costT[num].text = costs[num].ToString() + "$";

            
        }
    }

    public void SetVariables(Movement move, Drill dr){
        mm = move;
        d = dr;
    }
}
