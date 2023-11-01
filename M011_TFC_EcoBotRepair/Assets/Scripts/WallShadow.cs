using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallShadow : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    public GameObject camera;
    public GameObject target;

    public MeshRenderer CharacterTexture;
    public MeshRenderer CharacterTextureChain;

    public MeshRenderer CharacterStencil;
    public LayerMask layer;

    public Vector3 nuevaEscala;
    
    void Update()
    {
        RaycastHit hit;

        float distanciaMaxima = Vector3.Distance(camera.transform.position, target.transform.position);


        if (Physics.Raycast(camera.transform.position, (target.transform.position - camera.transform.position).normalized, out hit, distanciaMaxima, layer))
        {
            if (hit.collider.gameObject.tag == "Stencil")
            {
                target.transform.localScale = Vector3.zero; 
                print("not hit");

            }
            else
            {
                target.transform.localScale = nuevaEscala;
                print("hit");
            }


        }



    }
}
