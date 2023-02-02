using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClickAnimation : MonoBehaviour
{
    public Animator anim;
    public string animationName;
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
             anim.Play(animationName);
        }
    }
}
