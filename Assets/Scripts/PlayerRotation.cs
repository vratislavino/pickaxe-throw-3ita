using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerRotation : MonoBehaviour
{
    Transform trans;

    [SerializeField]
    Transform arms;

    [SerializeField]
    float speed;
    
    [Range(10,1000)]
    [SerializeField]
    float throwForce = 100;

    [SerializeField]
    Rigidbody pickaxe;
    Transform pickaxeTrans;
    Vector3 defaultLocalAxePosition;

    [SerializeField]
    ForceController forceController;

    bool thrown = false;
    bool settingForce = true;


    // Start is called before the first frame update
    void Start()
    {
        trans = gameObject.GetComponent<Transform>();
        pickaxeTrans = pickaxe.GetComponent<Transform>();
        forceController.ForceWasSet += OnForceWasSet;
        defaultLocalAxePosition = pickaxeTrans.localPosition;
    }

    private void OnForceWasSet() {
        Invoke("StartRotating", 0.1f);
    }

    private void StartRotating() {
        settingForce = false;
    }

    public void ResetPosition() {
        pickaxe.isKinematic = true;
        pickaxeTrans.localPosition = defaultLocalAxePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (settingForce)
            return;

        if(!thrown)
        trans.Rotate(Vector3.up, speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space)) {
            Throw();
            
        }

        if(thrown) {
            arms.rotation = Quaternion.Lerp(arms.rotation, Quaternion.Euler(-60, arms.rotation.eulerAngles.y, arms.rotation.eulerAngles.z), 0.91f);
        }
    }

    void Throw() {
        thrown = !thrown;
        pickaxe.isKinematic = false;

        float x = pickaxeTrans.position.x - trans.position.x;
        float z = pickaxeTrans.position.z - trans.position.z;
        Vector3 dir = new Vector3(x, 2.2f, z);
        
        dir.Normalize();
        pickaxe.AddForce(dir * throwForce * forceController.CurrentValue, ForceMode.Impulse);
    }
}
