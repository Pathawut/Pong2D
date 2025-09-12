using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour 
{
	public ScreenManager sceneManager;
	public float speed = 2.0f;
	public float bouceBorderSpeed = 1.5f;
	public float maxVelocity = 900;

	private Rigidbody2D rigid;
	private RectTransform rectTransform;
	private Vector3 startPosition;
	private Vector2 previousVelocity;

	void Start () 
	{
		rigid = GetComponent<Rigidbody2D>();
		rectTransform = gameObject.transform as RectTransform;
		if (rectTransform != null)
        {
			startPosition = rectTransform.position;
		}
		
		Reset();
	}

    void Update()
    {
		if (rigid != null && rigid.bodyType == RigidbodyType2D.Dynamic)
        {
			var v = rigid.linearVelocity;
			rigid.linearVelocity = Vector2.ClampMagnitude(v, maxVelocity);
		}
		
		if (Input.GetKeyDown(KeyCode.S))
        {
			Stop();
        }

		if (Input.GetKeyDown(KeyCode.R))
		{
			Resume();
		}
	}

    void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.tag == "Paddle") 
		{
			var vec = rigid.linearVelocity;
			rigid.linearVelocity = vec * speed;
		}
		else if (col.collider.tag == "Border")
		{
			
		}
		else if (col.collider.tag == "Brick") 
		{
			var brick = col.gameObject.GetComponent<Brick>();
			if (brick != null)
            {
				brick.OnHit();
			}
		}
	}

    void OnTriggerEnter2D(Collider2D col)
    {
		Reset();

		if (!sceneManager.Death())
        {
			Stop();
		}
	}

    public void Reset()
    {
		if (rigid != null && rectTransform != null)
        {
			rectTransform.position = startPosition;
			rigid.linearVelocity = RandomDirection() * 300;
		}
	}

    public void Stop()
    {
		if (rigid != null)
		{
			previousVelocity = rigid.linearVelocity;
			rigid.bodyType = RigidbodyType2D.Static;
		}
	}

	public void Resume()
	{
		if (rigid != null)
		{
			rigid.bodyType = RigidbodyType2D.Dynamic;
			rigid.linearVelocity = previousVelocity;
		}
	}

	private Vector2 RandomDirection()
    {
		Vector2 dir = Vector2.down;
		float rot = Random.Range(-0.78f, 0.78f);
		
		return RotateVector(dir, rot);
	}

	private Vector2 RotateVector(Vector2 v, float angle)
	{
		float _x = v.x * Mathf.Cos(angle) - v.y * Mathf.Sin(angle);
		float _y = v.x * Mathf.Sin(angle) + v.y * Mathf.Cos(angle);
		return new Vector2(_x, _y);
	}
}
