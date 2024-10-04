using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 8f;  // Kamera hareket hýzý
    public float panBorderThickness = 2f;  // Kenara yaklaþýnca kameranýn hareket etmeye baþlamasý için kalýnlýk (piksel cinsinden)

    public float scrollSpeed = 2f;  // Yakýnlaþtýrma/uzaklaþtýrma hýzý (Orthographic size için)
    public float minZoom = 5f;  // Minimum yakýnlaþtýrma
    public float maxZoom = 20f;  // Maksimum uzaklaþtýrma

    void Update()
    {
        // Kamerayý W, A, S, D ile hareket ettir
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

        // Kamera yakýnlaþtýrma/uzaklaþtýrma (orthographic size kullanarak)
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.orthographicSize -= scroll * scrollSpeed * 100f * Time.deltaTime;
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minZoom, maxZoom);

        // Yeni pozisyonu kameraya uygula
        transform.position = pos;
    }
}
