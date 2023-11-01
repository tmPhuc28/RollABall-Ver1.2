using UnityEngine;
public class CameraController : MonoBehaviour
{
    // Vật thể muốn camera quay
    public GameObject player;
    // Tọa độ của camera
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - player.transform.position;
    }
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}


