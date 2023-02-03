using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    SpriteRenderer rend;
    public Sprite[] sprites;
    int spriteindex;
    public float scaleGrow = 1;
    private Vector3 scale;
    Spawner spawner;

    [SerializeField] GameObject spawnerObj;
    [SerializeField] float spawnTime;
    bool isDone = false;


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        scale = transform.localScale;
        spriteindex = 0;
        rend.sprite = sprites[0];
        spawner = spawnerObj.GetComponent<Spawner>(); 
    }

    void Update()
    {
        if(!isDone)
        {
                if (sprites[spriteindex] == sprites[sprites.Length - 1])
                {
                    StartCoroutine(spawning());
                    isDone = true;
                }
        }
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
        scale = transform.localScale;
        transform.localScale = new Vector3(scale.x * scaleGrow, scale.y * scaleGrow, scale.z);

        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }

    }

    IEnumerator spawning()
    {
        while (sprites[spriteindex] == sprites[sprites.Length - 1])
        {
            yield return new WaitForSeconds(spawnTime);
            spawner.spawn();
        }
    }

    public void phaseChange()
    {
        StartCoroutine(Fading());
    }

}
