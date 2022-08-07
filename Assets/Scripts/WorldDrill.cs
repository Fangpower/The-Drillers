using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorldDrill : MonoBehaviour
{
    [SerializeField] Generator gen;
    [SerializeField] int baseCost = 200;
    [SerializeField] TMP_Text moneyT;
    [SerializeField] TMP_Text costT;
    [SerializeField] TMP_Text levelT;
    [SerializeField] GameObject store;
    [SerializeField] float max;

    [SerializeField] TMP_Text costLevelT;
    [SerializeField] TMP_Text levelLevelT;
    [SerializeField] Sprite[] gems;
    [SerializeField] Image gemIcon;
    [SerializeField] int levelCost = 100;
    [SerializeField] int maxLevelCost;

    private int current = 0;
    private int levelCurrent = 1;
    private int cash;

    private void Start(){
        gen = FindObjectOfType<Generator>();
    }

    private void Update(){
        int.TryParse(moneyT.text, out cash);
    }

    private void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            store.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D col){
        if(col.CompareTag("Player")){
            store.SetActive(false);
        }
    }

    public void Upgrade(){
        if(cash >= baseCost && current < max){
            current += 1;
            gen.tunnel[current-1] = true;
            gen.Destroyer();
            cash -= baseCost;
            moneyT.text = cash.ToString();
            baseCost += 200;
            costT.text = baseCost.ToString() + "$";
            levelT.text = (current).ToString();
            
            if(current == max){
                levelT.text = "Max";
                costT.text = "Max";
            }
        }
    }

    public void UpgradeWorld(){
        if(cash >= levelCost && levelCurrent < maxLevelCost){
            levelCurrent += 1;
            gen.height += 10;
            gen.Destroyer();
            cash -= levelCost;
            moneyT.text = cash.ToString();
            levelCost += 100;
            costLevelT.text = levelCost.ToString() + "$";
            levelLevelT.text = levelCurrent.ToString();
            gemIcon.sprite = gems[levelCurrent-1];
            if(levelCurrent == max){
                levelLevelT.text = "Max";
                costLevelT.text = "Max";
            }
        }
    }
}
