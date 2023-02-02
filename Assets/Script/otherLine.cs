using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otherLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector2 mousePos;
    private Vector2 currentMousePos;
    List<Vector3> positions = new();
    private int clickCounter;
  

    [SerializeField]

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        clickCounter = 0;
        lineRenderer.positionCount = 1;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lineRenderer.positionCount++;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            positions.Add(new Vector3(mousePos.x, mousePos.y, 0f));
            lineRenderer.SetPosition(clickCounter + 1, new Vector3(mousePos.x, mousePos.y, 0f));
            clickCounter++;
        }
        if (Input.GetMouseButton(0))
        {
            currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(clickCounter, new Vector3(currentMousePos.x, currentMousePos.y, 0f));

        }
    }
}
