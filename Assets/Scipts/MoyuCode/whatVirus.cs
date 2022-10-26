using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class whatVirus : MonoBehaviour
{
    public List<Sprite> images;
    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite= images[Random.Range(0, images.Count)];
        gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = images[Random.Range(0, images.Count)];
        gameObject.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sprite = images[Random.Range(0, images.Count)];
    }
}
