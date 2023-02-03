using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yaprak : MonoBehaviour
{

    public float fallingSpeed;
    public float fadingSpeed;
    SpriteRenderer rend;
    private Rigidbody2D rb;
    [SerializeField] float waitBeforeFade = 10;


    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0.0f, -fallingSpeed);
        StartCoroutine(Fading());
        rend.flipX = Random.value < 0.5;
    }

    IEnumerator Fading()
    {
        yield return new WaitForSeconds(waitBeforeFade);
        for (float f = 1f; f >= -fadingSpeed; f -= fadingSpeed)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(fadingSpeed);
        }
        Destroy(gameObject);
    }
}
