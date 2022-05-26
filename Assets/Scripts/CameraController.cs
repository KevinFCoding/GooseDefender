using UnityEngine;

public class CameraController : MonoBehaviour
{
    // TODO : Améliorer la gestion de caméra, voir forum caméra RTS dans la description de l'épisode 7


    private bool _doMovement = true;

    [SerializeField] float _panSpeed = 30f;
    [SerializeField] float _panBorderThickness = 10f;
    [SerializeField] float _scrollSpeed = 5f;
    [SerializeField] float _minY = 10f;
    [SerializeField] float _maxY = 80f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _doMovement = !_doMovement;
        }

        if (!_doMovement)
            return;

        if (Input.GetKey("z") || Input.mousePosition.y >= Screen.height - _panBorderThickness)
        {
            transform.Translate(Vector3.forward * _panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= _panBorderThickness)
        {
            transform.Translate(Vector3.back * _panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("q") || Input.mousePosition.x <= _panBorderThickness)
        {
            transform.Translate(Vector3.left * _panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - _panBorderThickness)
        {
            transform.Translate(Vector3.right * _panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * _scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, _minY, _maxY);

        transform.position = pos;
    }
}
