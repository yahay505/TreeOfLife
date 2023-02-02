using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otherLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector2 mousePos;
    Vector3[] positions;
    private int clickCounter;
  

    [SerializeField]

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        clickCounter = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            positions = new Vector3[clickCounter + 1];
            positions[clickCounter] = new Vector3(mousePos.x, mousePos.y, 0f);
            lineRenderer.SetPosition(clickCounter, positions[clickCounter]);
            clickCounter++;
            lineRenderer.positionCount = clickCounter + 2;
        }

        /*for (int i = 0; i < clickCounter; i++)
        {
            lineRenderer.SetPosition(i, positions[i]);
        }*/
    }
}
