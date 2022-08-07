using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudio : MonoBehaviour
{
    [SerializeField] AudioSource ad;

    public void PlaySound(){
        ad.pitch = 1 + Random.Range(-0.2f, 0.2f);
        ad.Play();
    }
}
