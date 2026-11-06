using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    private InputSystem_Actions inputActions;
	private Rigidbody2D rb;
	private SpriteRenderer sr;
    private Animator anim;

	[Header("Movement")]
    [SerializeField] private float speed = 5f;
    private Vector2 moveInput;
    
    [Header("Floor detection")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector2 checkSize = new Vector2(0.8f, 0.1f);
    [SerializeField] private float offsetY = 0.9f;
    private bool isGrounded;

    private bool isMoving;
    
    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Player.SetCallbacks(this);
    }

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
	}

	void Update()
	{
        CheckGrounded();

        isMoving = Mathf.Abs(moveInput.x) > 0.01f;

        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isMoving", isMoving);

		transform.Translate(moveInput * speed * Time.deltaTime);
	}

	private void OnEnable() => inputActions.Enable();

	private void OnDisable() => inputActions.Disable();

	public void OnChangeGravity(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            rb.gravityScale *= -1;

            if (sr.flipY) sr.flipY = false;
            else sr.flipY = true;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
		if (moveInput.x != 0) sr.flipX = moveInput.x < 0;
	}

    private void CheckGrounded()
    {
        float currentOffsetY = sr.flipY ? offsetY : -offsetY;
        Vector2 checkPosition = (Vector2)transform.position + new Vector2(0f, currentOffsetY);

        isGrounded = Physics2D.OverlapBox(checkPosition, checkSize, 0f, groundLayer);
    }
	private void OnDrawGizmos()
	{
		Gizmos.color = isGrounded ? Color.green : Color.red;
		float currentOffsetY = (sr != null && sr.flipY) ? offsetY : -offsetY;
		Vector2 checkPosition = (Vector2)transform.position + new Vector2(0f, currentOffsetY);
		Gizmos.DrawWireCube(checkPosition, checkSize);
	}
}
