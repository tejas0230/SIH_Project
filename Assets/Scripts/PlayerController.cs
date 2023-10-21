using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent agent;
    public Camera cam;
    public Animator animator;
    public LayerMask groundLayer;
    private CharacterController character;
    public bool UseWASD;
    Vector3 velocity;
    public float gravity;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rot = Quaternion.LookRotation(cam.transform.position, Vector3.up);
        transform.rotation = Quaternion.Euler(-rot.eulerAngles.x, 0, 0);

        if(character.isGrounded)
        {
            velocity.y = -2f;
        }
        if (GameManager.instance.CanPlayerMove)
        {   
            if (UseWASD)
            {
                float inputX = Input.GetAxis("Horizontal");
                float inputZ = Input.GetAxis("Vertical");
                if(inputX ==0 && inputZ==0)
                {
                    animator.SetBool("Move", false);
                }
                else
                {
                    animator.SetBool("Move", true);
                }
                animator.SetFloat("VelX", inputX);
                animator.SetFloat("VelZ", inputZ);
                Vector3 direction = Vector3.forward * inputZ + Vector3.right * inputX;

                character.Move(direction * Time.deltaTime * speed);
                velocity.y += gravity * Time.deltaTime;
                character.Move(velocity * Time.deltaTime);

            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, groundLayer))
                    {
                        agent.destination = hit.point;
                    }
                }

                if (agent.velocity != Vector3.zero)
                {
                    animator.SetBool("Move", true);
                }
                else
                {
                    animator.SetBool("Move", false);
                }
                animator.SetFloat("VelX", agent.velocity.normalized.x);
                animator.SetFloat("VelZ", agent.velocity.normalized.z);
            }
        }
    }
}
