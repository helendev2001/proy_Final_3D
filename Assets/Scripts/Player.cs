using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float vMoviento = 5.0f;
    public float vRotacion = 200.0f;

    private Animator player;
    public float x, y;


    public Rigidbody rb;
    public float fuerzaSalto = 8f;
    public bool puedoSaltar;
    // Start is called before the first frame update
    void Start()
    {
      puedoSaltar=false;
      player = GetComponent <Animator> (); 
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, x * Time.deltaTime * vRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * vMoviento);


    }
    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

      
        player.SetFloat("vX", x);
        player.SetFloat("vY", y);

        
            if(Input.GetKeyDown(KeyCode.Space))
            {
                player.SetBool("salto",true);
                rb.AddForce(new Vector3 (0, fuerzaSalto, 0), ForceMode.Impulse);
                player.SetBool("TocaSuelo", false);

            }
            else
            {
                estoyCayendo();
            }
        

    }
    public void estoyCayendo()
    {
        player.SetBool("TocaSuelo", false);
        player.SetBool("salto", false);
    }
}
