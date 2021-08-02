using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightInditator : MonoBehaviour
{
    public GameObject sphere;
    [Space]
    public Color colorON;
    public Color colorOFF;
    [Space]
    public ChangeColorOfDots masterColor;

    Gradient gradient;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;

    private void Start() { colorON = masterColor.act_selectedColor.color; gradienter(); }

    private void OnTriggerStay(Collider other) 
    {
        float r = sphere.transform.gameObject.GetComponent<SphereCollider>().radius*sphere.transform.localScale.x;
        Vector3 center = sphere.transform.position;

        if (Vector3.Distance(center, transform.position) <= r)
        {
            float value= Mathf.Lerp(1, 0, Mathf.InverseLerp(0, r, Vector3.Distance(center, transform.position)));

            transform.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", gradient.Evaluate(value));   
        }
    }
    private void OnTriggerExit(Collider other) { transform.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black); }

    void gradienter()
    {
        gradient = new Gradient();

        colorKey = new GradientColorKey[2];
        colorKey[0].color = colorOFF;
        colorKey[0].time = 0.0f;
        colorKey[1].color = colorON;
        colorKey[1].time = 1.0f;

        alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 0.0f;
        alphaKey[1].time = 1.0f;

        gradient.SetKeys(colorKey, alphaKey);
    }

    private void Update()
    {
        //colorON = masterColor.act_selectedColor.color;
        colorON= Color.Lerp(colorON, masterColor.act_selectedColor.color, Time.deltaTime);
        gradienter();
    }
}
