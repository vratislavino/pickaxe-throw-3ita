using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceController : MonoBehaviour
{
    public event Action ForceWasSet;

    [SerializeField]
    Transform valueTrans;

    [SerializeField]
    float speed = 1;

    float currentValue = 0;
    public float CurrentValue => currentValue;

    bool goinDown = false;

    bool isRunning = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isRunning) {
            if(Input.GetKeyDown(KeyCode.Space)) {
                isRunning = false;
                ForceWasSet.Invoke();
            }

            if (goinDown) {
                currentValue -= Time.deltaTime * speed;
                if (currentValue <= 0) {
                    goinDown = false;
                }
            } else {
                currentValue += Time.deltaTime * speed;
                if (currentValue >= 1) {
                    goinDown = true;
                }
            }

            valueTrans.localScale = new Vector3(currentValue, 1, 1);
        }


        

    }
}
