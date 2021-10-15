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

    [SerializeField]
    Rigidbody pickaxe;
    Transform pickaxeTrans;

    bool thrown = false;

    // Start is called before the first frame update
    void Start()
    {
        trans = gameObject.GetComponent<Transform>();
        pickaxeTrans = pickaxe.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
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

        float x = trans.position.x - pickaxeTrans.position.x;
        float z = trans.position.z - pickaxeTrans.position.z;
        Vector3 dir = new Vector3(x, 2.2f, z);
        Debug.Log(dir);
        dir.Normalize();
        pickaxe.AddForce(dir * 10, ForceMode.Impulse);
    }
}
