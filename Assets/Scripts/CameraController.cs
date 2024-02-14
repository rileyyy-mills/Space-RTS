using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panBase, panSpeed = 20f;
    public float panBoarderThickness = 10f;
    public Vector2 panLimit;

    public float minY = -810f;
    public float maxY = -400f;
    public float scrollBase, scrollSpeed = 200f;
    public float panModifier, scrollModifier = 2;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        /*if (Input.GetKeyDown(KeyCode.LeftShift)){
            panSpeed *= panModifier;
        }
        else {
            panSpeed = panBase;
        }

        if (Input.GetKeyDown(KeyCode.Mouse2)){
            scrollSpeed *= scrollModifier;
        }
        else {
            scrollSpeed = scrollBase;
        }
        */

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBoarderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= - panBoarderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBoarderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBoarderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        pos.y -= scrollWheel * scrollSpeed * 1000f * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);
        
        transform.position = pos;
    }
}
