using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Roots : MonoBehaviour
{
    public ComputeShader computeShader;

    public ComputeBuffer lines;
    public RenderTexture mainText,vectText;

    private int CSMain, GenForceField;
    // Start is called before the first frame update
    void Awake()
    {




        CSMain = computeShader.FindKernel("CSMain");
        GenForceField = computeShader.FindKernel("GenForceField");
        mainText = new RenderTexture(256, 256, 24);
        mainText.enableRandomWrite = true;
        mainText.Create();
        computeShader.SetTexture(CSMain,"Result",mainText);
        
        vectText = new RenderTexture(1024, 1024, 24);
        vectText.enableRandomWrite = true;
        vectText.Create();
        computeShader.SetTexture(GenForceField,"VectorSpace",vectText);

        
        
        computeShader.SetBool("first",true);
        computeShader.Dispatch(0,mainText.width/8,mainText.height/8,1);
        computeShader.SetBool("first",false);
        GetComponent<MeshRenderer>().material.mainTexture = mainText;

    }

    // Update is called once per frame
    void Update()
    {
    }


    private List<Vector4> instructions=new List<Vector4>();
    private void OnGUI()
    {
        if (GUI.Button(new Rect(50,20,100,30),"Step"))
        {
            computeShader.Dispatch(CSMain,mainText.width/8,mainText.height/8,1);
        }
        if (GUI.Button(new Rect(160,20,100,30),"vectorSpace"))
        {
            computeShader.Dispatch(GenForceField,1,1,1);
            GetComponent<MeshRenderer>().material.mainTexture = vectText;

        }

        var from = (GUI.TextField(new Rect(50,80,50,25),  "from x,y").Split(",")).Select(float.Parse).ToArray();
        var to = (GUI.TextField(new Rect(110,80,50,25),  "to x,y").Split(",")).Select(float.Parse).ToArray();
        if (GUI.Button(new Rect(180,80,50,25),"add"))
        {
instructions.Add(new Vector4(from[0],from[1],to[0],to[1]));
        }
        
        //TODO call the shader pass new buffer
    }
}

