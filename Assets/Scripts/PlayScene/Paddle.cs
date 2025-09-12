using UnityEngine;
using UnityEngine.UI;

public class Paddle : MonoBehaviour
{
	public float speed = 500.0f;

	public UIButtonPress leftButton;
	public UIButtonPress rightButton;

	private Rigidbody2D rigid;

	void Start()
	{
		rigid = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () 
	{
		if (rigid != null)
		{
			float direction = Input.GetAxis("Horizontal");
			if (leftButton.Pressed)
			{
				direction += -1.0f;
			}
			
			if (rightButton.Pressed)
			{
				
				direction += 1.0f;
			}
			/**/
			
			Vector3 movement = new Vector3(direction, 0.0f, 0.0f);
			rigid.velocity = (movement * speed);
		}
	}

}
