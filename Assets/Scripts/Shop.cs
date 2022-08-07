using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private Generator gen;
    private AudioSource ad;
    private Movement mm;

    [SerializeField] int[] prices;
    [SerializeField] TMP_Text[] resources;
    [SerializeField] TMP_Text money;
    [SerializeField] Image coinImg;
    [SerializeField] ParticleSystem[] parts;
    [SerializeField] ParticleSystem cashPart;
    [SerializeField] TMP_Text fpsText;

    float deltaTime;

    private void Start(){
        gen = FindObjectOfType<Generator>();
        ad = GetComponent<AudioSource>();
    }

    private void Update(){
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Ceil(fps).ToString() + "FPS";
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            mm = col.transform.GetComponent<Movement>();
            StartCoroutine("Sell");
            gen.Destroyer();
        }
    }

    private IEnumerator Sell(){
        if(money.text == ""){
            coinImg.color = new Color32(255, 255, 255, 255);
        }
        mm.enabled = false;
        cashPart.Play();
        FindObjectOfType<Drill>().Refill();
        ad.Play();
        for(int i = 0; i < resources.Length; i++){
            int resource;
            int cash;
            int.TryParse(resources[i].text, out resource);
            int.TryParse(money.text, out cash);

            int vis = resource;
            resource *= prices[i];
            int ves = cash;

            parts[i].Play();
            while(vis > 0){
                vis -= 1;
                ves += prices[i];
                resources[i].text = vis.ToString();
                money.text = ves.ToString();
                yield return new WaitForSeconds(0.025f);
            }
            parts[i].Stop();

            if(resources[i].text != ""){resources[i].text = "0";}
            cash += resource;
            money.text = cash.ToString();
        }
        mm.enabled = true;
        cashPart.Stop();
        ad.Stop();
        yield return null;
    }
}
