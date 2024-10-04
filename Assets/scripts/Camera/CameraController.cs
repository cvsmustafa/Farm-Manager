using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 8f;  // Kamera hareket h�z�
    public float panBorderThickness = 2f;  // Kenara yakla��nca kameran�n hareket etmeye ba�lamas� i�in kal�nl�k (piksel cinsinden)

    public float scrollSpeed = 2f;  // Yak�nla�t�rma/uzakla�t�rma h�z� (Orthographic size i�in)
    public float minZoom = 5f;  // Minimum yak�nla�t�rma
    public float maxZoom = 20f;  // Maksimum uzakla�t�rma

    void Update()
    {
        // Kameray� W, A, S, D ile hareket ettir
        Vector3 pos = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        // Kamera yak�nla�t�rma/uzakla�t�rma (orthographic size kullanarak)
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.orthographicSize -= scroll * scrollSpeed * 100f * Time.deltaTime;
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minZoom, maxZoom);

        // Yeni pozisyonu kameraya uygula
        transform.position = pos;
    }
}
