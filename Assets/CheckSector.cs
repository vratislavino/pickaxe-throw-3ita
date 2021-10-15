using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSector : MonoBehaviour
{
    
    Renderer rend;
    Collider axe;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();    
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Pickaxe")) {
            rend.material.color = new Color(0f, 1f, 0f, 0.1f);

            axe = other;

            GameObject g = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            g.transform.localScale *= 0.3f;
            g.transform.position = other.transform.position;
            Invoke("ResetAxePosition", 1);
        }
    }

    private void ResetAxePosition() {
        axe.GetComponentInParent<PlayerRotation>().ResetPosition();

        rend.material.color = new Color(1f, 0f, 0f, 0.1f);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
