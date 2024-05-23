using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCamera : MonoBehaviour
{
	//public Camera FlyCam;
    public Camera FlyCam;
    public float moveSpeed = 5f;
    public float rotationSpeed = 2f;

    private float rotationX = 0f;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float moveUpDown = Input.GetAxis("VerticalMovement"); // Nuevo eje para el movimiento vertical

        Vector3 moveDirection = transform.right * moveHorizontal + transform.forward * moveVertical + transform.up * moveUpDown; // Utiliza transform.up para el movimiento vertical
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        // Rotar alrededor del eje Y para girar la cámara a la izquierda y a la derecha
        transform.Rotate(Vector3.up, mouseX);

        // Acumular la rotación en X para evitar la rotación infinita y clamp la rotación para evitar que la cámara dé la vuelta
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Ajusta los límites según sea necesario

        // Aplicar la rotación acumulada en el eje X
        FlyCam.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }

}
