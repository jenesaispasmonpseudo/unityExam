using UnityEngine;
using System.Collections;

namespace UnityChan
{
	[RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(CapsuleCollider))]
	[RequireComponent(typeof(Rigidbody))]

	public class UnityChanControlScriptWithRgidBody : MonoBehaviour
	{

		public float animSpeed = 1.5f;	
		public float lookSmoother = 3.0f;			
		public bool useCurves = true;				
		public float useCurvesHeight = 0.5f;		

		public float forwardSpeed = 7.0f; 
		public float backwardSpeed = 2.0f; 
		public float rotateSpeed = 2.0f; 

		private CapsuleCollider col;
		private Rigidbody rb;
		private Vector3 velocity;

		private float orgColHight;
		private Vector3 orgVectColCenter;
		private Animator anim;	
		private AnimatorStateInfo currentBaseState; 

		private GameObject cameraObject; 

		static int idleState = Animator.StringToHash("Base Layer.Idle");
		static int locoState = Animator.StringToHash("Base Layer.Locomotion");
		static int restState = Animator.StringToHash("Base Layer.Rest");

		void Start()
		{
			anim = GetComponent<Animator>();
			col = GetComponent<CapsuleCollider>();
			rb = GetComponent<Rigidbody>();
			cameraObject = GameObject.FindWithTag("MainCamera");

			orgColHight = col.height;
			orgVectColCenter = col.center;
		}

		void FixedUpdate()
		{
			float h = Input.GetAxis("Horizontal"); 
			float v = Input.GetAxis("Vertical");   
			anim.SetFloat("Speed", v);	
			anim.SetFloat("Direction", h);	
			anim.speed = animSpeed;	
			currentBaseState = anim.GetCurrentAnimatorStateInfo(0);	
			rb.useGravity = true; 
			velocity = new Vector3(0, 0, v); 
			velocity = transform.TransformDirection(velocity); 

			if (v > 0.1f) {
				velocity *= forwardSpeed; 
			} else if (v < -0.1f) {
				velocity *= backwardSpeed; 
			}

			transform.localPosition += velocity * Time.fixedDeltaTime; 

			transform.Rotate(0, h * rotateSpeed, 0); 

			
			if (currentBaseState.fullPathHash == locoState) {
				if (useCurves) {
					resetCollider(); 
				}
			}

			if (currentBaseState.fullPathHash == idleState) {
				if (useCurves) {
					resetCollider(); 
				}
			}

			if (currentBaseState.fullPathHash == restState) {
				if (!anim.IsInTransition(0)) {
					anim.SetBool("Rest", false);
				}
			}
		}

		void resetCollider()
		{
			col.height = orgColHight;
			col.center = orgVectColCenter;
		}
	}
}
