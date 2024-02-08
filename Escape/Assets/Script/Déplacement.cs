using UnityEngine;

public class Déplacement : MonoBehaviour
{
    public float vitesseDeplacement = 5f;
    public float vitesseRotationCamera = 3f;

    void Update()
    {
        // Déplacement
        float deplacementHorizontal = Input.GetAxis("Horizontal");
        float deplacementVertical = Input.GetAxis("Vertical");

        Vector3 deplacement = new Vector3(deplacementHorizontal, 0f, deplacementVertical) * vitesseDeplacement * Time.deltaTime;
        transform.Translate(deplacement);

        // Rotation de la caméra
        if (Input.GetMouseButton(0))
        {
            float rotationX = Input.GetAxis("Mouse X") * vitesseRotationCamera;
            float rotationY = Input.GetAxis("Mouse Y") * vitesseRotationCamera;

            transform.Rotate(new Vector3(-rotationY, rotationX,0));
        }
    }
}