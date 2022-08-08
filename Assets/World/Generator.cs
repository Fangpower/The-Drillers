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
    [SerializeField] GameObject[] rareOre;
    public bool[] tunnel;
    [SerializeField] GameObject tunnelObj;
    [SerializeField] GameObject permaGround;
    [SerializeField] GameObject bomb;

    private void Start(){
        Application.targetFrameRate = 300;
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
                    if(Random.Range(0, 100) < 2f && x != 12 && layer != 0){
                        var temp = Instantiate(bomb, transform.position + new Vector3(x, y, 0), Quaternion.identity);
                        temp.transform.SetParent(transform);
                    } else if(Random.Range(0, 100) < 2 && x != 12){
                        Maker(rareOre, layer, x, y);
                    } else if(Random.Range(0, 100) < oreChance[layer] && x != 12){
                        Maker(ore, layer, x, y);
                    } else if(x != 12) {
                        Maker(ground, layer, x, y);
                    } else {
                        var temp = Instantiate(tunnelObj, transform.position + new Vector3(x, y, 0), Quaternion.identity);
                        temp.transform.SetParent(transform);
                    }
                } else {
                    if(Random.Range(0, 100) < 2f && layer != 0){
                        var temp = Instantiate(bomb, transform.position + new Vector3(x, y, 0), Quaternion.identity);
                        temp.transform.SetParent(transform);
                    } else if(Random.Range(0, 100) < 2){
                        Maker(rareOre, layer, x, y);
                    } else if(Random.Range(0, 100) < oreChance[layer]){
                        Maker(ore, layer, x, y);
                    } else {
                        Maker(ground, layer, x, y);
                    }
                }
                
            }
        }

        for(int x = 0; x < width; x += 2){
            for(int y = (int)-height; y > -height - 6; y -= 2){
                var temp = Instantiate(permaGround, transform.position + new Vector3(x, y, 0), Quaternion.identity);
                temp.transform.SetParent(transform);
            }
        }
    }

    private void Maker(GameObject[] obj, int layer, int x, int y){
        var temp = Instantiate(obj[layer], transform.position + new Vector3(x, y, 0), Quaternion.identity);
        temp.transform.SetParent(transform);
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
