using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inditatorsCyrcleDraw : MonoBehaviour
{
    public ChangeNumberOfDots dots;
    [Min(4)]
    private int numberOfInditators=12;
    public GameObject defaultIndicatorPosition;
    [Tooltip("for taking color correctly")]
    public GameObject defaultIndicator;
    public float y=0f;

    private Transform initialIndicatorPosition;
    private int new_N_Indicators;
    void Start()
    {
        numberOfInditators=Int32.Parse(dots.textNumberOfDots.text);

        new_N_Indicators = numberOfInditators;

        initialIndicatorPosition = defaultIndicatorPosition.transform;

        int degree = 360 / numberOfInditators;
        for (int i = 0; i < 360; i += degree)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, i));
            
            GameObject newInd=GameObject.Instantiate(defaultIndicator);
            newInd.transform.localPosition = new Vector3(initialIndicatorPosition.localPosition.x, y, initialIndicatorPosition.localPosition.z);
            
            newInd.transform.parent = transform;
            newInd.active = true;
        }
    }

    private void Update()
    {
        numberOfInditators = Int32.Parse(dots.textNumberOfDots.text);

        if (numberOfInditators != new_N_Indicators)
        {
            foreach (Transform child in transform)          
                if (child.gameObject.active && !child.gameObject.name.Equals("indicator"))  
                    GameObject.Destroy(child.gameObject);

            initialIndicatorPosition = defaultIndicatorPosition.transform;

            int degree = 360 / numberOfInditators;
            
            for (int i = 0; i < 360; i += degree)
            {
                transform.localRotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, i));

                GameObject newInd = GameObject.Instantiate(defaultIndicator);
                newInd.transform.localPosition = new Vector3(initialIndicatorPosition.localPosition.x, y, initialIndicatorPosition.localPosition.z);

                newInd.transform.parent = transform;
                newInd.active = true;
            }
        }

        new_N_Indicators = numberOfInditators;
    }
}
