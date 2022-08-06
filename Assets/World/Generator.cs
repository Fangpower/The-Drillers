using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] float width;
    public float height;
    [SerializeField] float layerSize;
    [SerializeField] float[] oreChance;
    [SerializeField] GameObject[] ground;
    [SerializeField] GameObject[] ore;
    public bool[] tunnel;
    [SerializeField] GameObject tunnelObj;
    [SerializeField] GameObject permaGround;

    private void Start(){
        Creator();
    }

    private void Creator(){
        int layer = 0;
        for(int x = 0; x < width; x+=2){
            for(int y = 0; y > -height; y-=2){
                if(y == 0){
                    layer = 0;
                } else if(y % layerSize == 0){
                    layer++;
                }
                if(tunnel[layer]){
                    if(Random.Range(0, 100) < oreChance[layer] && x != 12){
                        var tempFG = Instantiate(ore[layer], transform.position + new Vector3(x, y, 0), Quaternion.identity);
                        tempFG.transform.SetParent(transform);
                    } else if(x != 12) {
                        var tempFG = Instantiate(ground[layer], transform.position + new Vector3(x, y, 0), Quaternion.identity);
                        tempFG.transform.SetParent(transform);
                    } else {
                        var tempBG = Instantiate(tunnelObj, transform.position + new Vector3(x, y, 0), Quaternion.identity);
                        tempBG.transform.SetParent(transform);
                    }
                } else {
                    if(Random.Range(0, 100) < oreChance[layer]){
                        var tempFG = Instantiate(ore[layer], transform.position + new Vector3(x, y, 0), Quaternion.identity);
                        tempFG.transform.SetParent(transform);
                    } else {
                        var tempFG = Instantiate(ground[layer], transform.position + new Vector3(x, y, 0), Quaternion.identity);
                        tempFG.transform.SetParent(transform);
                    }
                }
                
            }
        }

        for(int x = 0; x < width; x += 2){
            for(float y = -height; y > -height - 6; y -= 2){
                var tempFG = Instantiate(permaGround, transform.position + new Vector3(x, y, 0), Quaternion.identity);
                tempFG.transform.SetParent(transform);
            }
        }
    }

    public void Destroyer(){
        foreach(Transform child in GetComponentsInChildren<Transform>()){
            if(child.transform != this.transform){
                GameObject.Destroy(child.gameObject);
            }
        }
        Creator();
    }
}
