using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class photoAnimation : MonoBehaviour
{
    [SerializeField] GameObject photo;
    PhotoCapture photocapture;
    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
        photocapture = photo.GetComponent<PhotoCapture>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
