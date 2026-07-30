using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform playerTarget;
    public Camera camera;
    // public float cameraDistance = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, playerTarget.position.z);
    }
}
