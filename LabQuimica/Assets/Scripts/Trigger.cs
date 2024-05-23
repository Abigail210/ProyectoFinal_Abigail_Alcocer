using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool entro = false;
    public Vector3 labelPosition = new Vector3(-5.83f, -4.076f, -7.55f); // Posición normalizada de la etiqueta (0 a 1)
    public float labelWidth = 200f; // Ancho de la etiqueta
    public float labelHeight = 500f; // Alto de la etiqueta

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            entro = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            entro = false;
        }
    }

    void OnGUI()
    {
        if (entro)
        {
            // Convertir la posición normalizada a píxeles
            float posX = labelPosition.x * Screen.width;
            float posY = labelPosition.y * Screen.height;

            // Calcular la posición Z (no normalizada)
            float posZ = labelPosition.z;

            // Crear la etiqueta en la posición calculada
            GUI.Label(new Rect(posX, posY, labelWidth, labelHeight), "Gradillas tubo ensayo");
        }
    }
}

/*pragma script

var entro: boolean = false;

function OnTriggerEnter(){ 

	entro = true;
}

function OnTriggerExit(){
	entro = true;
}

function OnGUI(){
	
	if(entro == true){
		GUI.Label(Rect(Screen.width/2, Screen.heaight/2,200,30), "Gradillas tubo ensayo");
	}
}*/