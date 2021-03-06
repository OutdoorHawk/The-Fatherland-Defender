using UnityEngine;

public class CameraController : MonoBehaviour {

	[SerializeField] private float _panSpeed = 10f;
    [SerializeField] private float _panBorderThickness = 10f;

    [SerializeField] private float _scrollSpeed = 5f;
    [SerializeField] private float _minY = 1f;
    [SerializeField] private float _maxY = 5f;

	
	void LateUpdate () {

		if (GameProcess.gameFinished)
		{
			this.enabled = false;
			return;
		}

 

		if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - _panBorderThickness )
		{
            if (transform.position.z < 4)
            {
				transform.Translate(Vector3.forward * _panSpeed * Time.deltaTime, Space.World);
			}
          
		}
		if (Input.GetKey("s") || Input.mousePosition.y <= _panBorderThickness )
		{
			if (transform.position.z > -11)
			{
				transform.Translate(Vector3.back * _panSpeed * Time.deltaTime, Space.World);
			}
		}
		if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - _panBorderThickness)
		{
            if (transform.position.x < 1)
            {
				transform.Translate(Vector3.right * _panSpeed * Time.deltaTime, Space.World);
			}
			
		}
		if (Input.GetKey("a") || Input.mousePosition.x <= _panBorderThickness)
		{
			if (transform.position.x > -17)
			{
				transform.Translate(Vector3.left * _panSpeed * Time.deltaTime, Space.World);
			}
		}

		float scroll = Input.GetAxis("Mouse ScrollWheel");

		Vector3 pos = transform.position;

        
		pos.y -= scroll * 1000 * _scrollSpeed * Time.deltaTime;
		pos.y = Mathf.Clamp(pos.y, _minY, _maxY);

		transform.position = pos;

	}

   
}
