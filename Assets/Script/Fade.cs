using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    SpriteRenderer rend;
    public Sprite[] sprites;
    public int spriteindex;


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        spriteindex = 0;
        rend.sprite = sprites[0];
    }
    IEnumerator Fading()
    {
        for (float f = 1f; f >= 0f; f -= 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }

        spriteindex++;
        rend.sprite = sprites[spriteindex];

        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void phaseChange()
    {
        StartCoroutine(Fading());
    }

}
