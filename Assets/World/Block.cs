using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Block : MonoBehaviour
{
    [SerializeField] SpriteRenderer overlay;
    [SerializeField] Sprite[] overlays;
    [SerializeField] float maxHealth;
    [SerializeField] ParticleSystem brokenParts;
    [SerializeField] LayerMask groundMask;
    [SerializeField] bool rareOre;
    [SerializeField] bool bomb;

    public float health;
    private int current;
    private TMP_Text text;
    private Image visual;
    private SpriteRenderer sr;
    private AudioSource ad;

    private void Awake(){
        health = maxHealth;
        sr = GetComponent<SpriteRenderer>();
        ad = transform.parent.GetComponent<AudioSource>();
        sr.color = Color.black;

        switch(transform.name){
            case "Copper": text = GameObject.Find("CopperText").GetComponent<TMP_Text>(); visual = GameObject.Find("CopperImg").GetComponent<Image>(); break;
            case "Iron": text = GameObject.Find("IronText").GetComponent<TMP_Text>(); visual = GameObject.Find("IronImg").GetComponent<Image>(); break;
            case "Gold": text = GameObject.Find("GoldText").GetComponent<TMP_Text>(); visual = GameObject.Find("GoldImg").GetComponent<Image>(); break;
            case "Diamond": text = GameObject.Find("DiamondText").GetComponent<TMP_Text>(); visual = GameObject.Find("DiamondImg").GetComponent<Image>(); break;
            case "Uranium": text = GameObject.Find("UraniumText").GetComponent<TMP_Text>(); visual = GameObject.Find("UraniumImg").GetComponent<Image>(); break;
            case "Amathyst": text = GameObject.Find("AmathystText").GetComponent<TMP_Text>(); visual = GameObject.Find("AmathystImg").GetComponent<Image>(); break;
            case "Black": text = GameObject.Find("BlackText").GetComponent<TMP_Text>(); visual = GameObject.Find("BlackImg").GetComponent<Image>(); break;
            case "White": text = GameObject.Find("WhiteText").GetComponent<TMP_Text>(); visual = GameObject.Find("WhiteImg").GetComponent<Image>(); break;
        }
    }

    public void Damage(float damage){
        health -= damage * Time.deltaTime;
    }

    private void Update(){
        if(health <= 0){
            if(text && text.text == ""){
                visual.color = new Color32(255, 255, 255, 255);
            }
            ad.pitch = 1 + Random.Range(-0.2f, 0.2f);
            ad.Play();
            brokenParts.transform.parent = null;
            brokenParts.transform.localScale = new Vector3(1, 1, 1);
            brokenParts.Play();
            if(text){
                int.TryParse(text.text, out current);
                if(rareOre) current += Random.Range(6, 10);
                else current += Random.Range(2, 5);
                text.text = current.ToString();
            }
            if(bomb){
                Collider2D[] surrounding = Physics2D.OverlapCircleAll(transform.position, 1.1f, groundMask);
                foreach(Collider2D coll in surrounding){
                    coll.GetComponent<Block>().health = 0;
                }
                FindObjectOfType<Drill>().fuel /= 2;
            }
            GameObject.Destroy(gameObject);
        }
        
        int percent = (int)((health/maxHealth)*100);
        if(percent >= 80){
            overlay.sprite = overlays[0];
        } else if(percent >= 60){
            overlay.sprite = overlays[1];
        } else if(percent >= 40){
            overlay.sprite = overlays[2];
        } else if(percent >= 20){
            overlay.sprite = overlays[3];
        } else{
            overlay.sprite = overlays[4];
        }

        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, 1.1f, groundMask);
        if(col.Length < 5){
            sr.color = Color.white;
        }
        
    }

    void OnDrawGizmos(){
        Gizmos.DrawWireSphere(transform.position, 1.1f);
    }
}
