using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    [SerializeField] GameObject ppv;
    [SerializeField] AudioLowPassFilter alpf;
    [SerializeField] bool main;

    void Start(){
        if(main){
            ppv.SetActive(true);
            alpf = GetComponent<AudioLowPassFilter>();
        }
    }

    void Update()
    {
        if(player) transform.position = new Vector3(0, player.position.y, -10);

        if(main){
            if(transform.position.y <= -4){
                alpf.enabled = (true);
            } else {
                alpf.enabled = (false);
            }
        }
    }
}
