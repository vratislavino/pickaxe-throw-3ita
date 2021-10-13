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

    bool thrown = false;

    // Start is called before the first frame update
    void Start()
    {
        trans = gameObject.GetComponent<Transform>();
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
            arms.rotation = Quaternion.Lerp(arms.rotation, Quaternion.Euler(-60, 0, 0), 0.2f);
        }


    }

    void Throw() {
        thrown = !thrown;
    }
}
