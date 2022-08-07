using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drill : MonoBehaviour
{
    private PlayerControl pc;
    private Camera cam;
    private Animator anim;
    private float fuel;

    [SerializeField] BoxCollider2D bc;
    [SerializeField] Image fuelFill;
    [SerializeField] float maxFuel;
    [SerializeField] float damage = 1;
    [SerializeField] Transform[] arms;
    [SerializeField] AudioSource sound;
    [SerializeField] GameObject uiOne, uiTwo;
    
    public float fuelLevel;
    public float damageLevel;

    

    void Awake()
    {
        uiOne = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        uiTwo = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
        pc = new PlayerControl();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        anim = GetComponent<Animator>();
        fuel = maxFuel; 
    }

    private void OnEnable(){
        pc.Enable();
    }

    private void OnDisable(){
        pc.Disable();
    }

    private void Start(){
        fuelFill = GameObject.Find("FuelFG").GetComponent<Image>();
    }

    void Update(){
        maxFuel = 10 + (fuelLevel * 5);
        damage = 1 + (damageLevel/2);
        //Drill rotation
        Vector2 mouseRaw = pc.Controls.Mouse.ReadValue<Vector2>();
        Vector2 mouse = cam.ScreenToWorldPoint(new Vector2(mouseRaw.x, mouseRaw.y));
        Vector2 direction = (mouse - (Vector2) transform.position).normalized;
        transform.up = direction;

        arms[0].up = -direction;
        arms[1].up = -direction;
        
        fuelFill.fillAmount = fuel/maxFuel;

        if(pc.Controls.Mine.ReadValue<float>() == 1 && fuel > 0 && !uiOne.activeSelf && !uiTwo.activeSelf){
            anim.SetBool("Use", true);
            if(!sound.isPlaying){
                sound.Play();
            }
            
        } else {
            anim.SetBool("Use", false);
            sound.Stop();
        }
    }

    void OnTriggerStay2D(Collider2D col){
        if(pc.Controls.Mine.ReadValue<float>() == 1 && col.CompareTag("Breakable") && fuel > 0){
            col.GetComponent<Block>().Damage(damage);
            fuel -= 1 * Time.deltaTime;
            fuel = Mathf.Clamp(fuel, 0, maxFuel);
        }
    }

    void OnTriggerExit2D(Collider2D col){
        anim.SetBool("Use", false);
    }

    public void Refill(){
        fuel = maxFuel;
    }
}
