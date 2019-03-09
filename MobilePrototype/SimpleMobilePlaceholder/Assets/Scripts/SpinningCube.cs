using UnityEngine;
using System.Collections;

public class SpinningCube : MonoBehaviour 
{
	public float m_Speed = 20f;

	private Vector3 m_RotationDirection = Vector3.up;

	public void ToggleRotationDirection()
	{
		

		if (m_RotationDirection == Vector3.up) 
		{
			m_RotationDirection = Vector3.down;
            Debug.Log("Toggling rotation direction down");
        }
		else 
		{
			m_RotationDirection = Vector3.up;
            Debug.Log("Toggling rotation direction up");
        }
	}

	void Update() 
	{
		transform.Rotate(m_RotationDirection * Time.deltaTime * m_Speed);
	}
}
