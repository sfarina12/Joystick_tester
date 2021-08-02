using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRegister : MonoBehaviour
{
    public CheckForController controller;
    public Transform stickPivot;
    public Transform LighterPivot;
    public Transform LighterDistancer;
    [Space]
    public float rotationMultiply = 1;
    public float rotationLighterMultiply = 1f;
    public float smoothRotation = 2f;

    private Transform LigherinitialPosition;
    private float OriginalLighterDistancer;


    void Start()
    {
        LigherinitialPosition = LighterPivot;
        //OriginalLighterDistancer = LighterDistancer.position.x;
        OriginalLighterDistancer = 2.06f;
    }

    void Update()
    {
        if (controller.isControllerConnected)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            Quaternion finalRotation = Quaternion.Euler(new Vector3(y * rotationMultiply, 0, -x * rotationMultiply));
            stickPivot.localRotation = Quaternion.Slerp(stickPivot.localRotation, finalRotation, Time.deltaTime * smoothRotation);

            if (x == 0 & y == 0)
            {
                if (LighterDistancer.localPosition != Vector3.zero)
                    LighterDistancer.localPosition = Vector3.Lerp(LighterDistancer.localPosition, Vector3.zero, Time.deltaTime * smoothRotation);

            }
            else
            {
                if (LighterDistancer.localPosition.x != OriginalLighterDistancer)
                {
                    float appX = x;
                    float appY = y;

                    if (x < 0) appX *= -1;
                    if (y < 0) appY *= -1;

                    float actValue = appX + appY;

                    if (actValue > 1) actValue = 1;

                    Vector3 newPos = new Vector3(OriginalLighterDistancer * actValue, LighterDistancer.localPosition.y, LighterDistancer.localPosition.z);
                    LighterDistancer.localPosition = Vector3.Lerp(LighterDistancer.localPosition, newPos, Time.deltaTime * smoothRotation);
                }

                float angle = Mathf.Atan2(y, x);
                finalRotation = Quaternion.Euler(new Vector3(0, -angle * (rotationMultiply * rotationLighterMultiply), 0));
                LighterPivot.localRotation = Quaternion.Slerp(LighterPivot.localRotation, finalRotation, Time.deltaTime * smoothRotation);
            }
        }
    }
}
