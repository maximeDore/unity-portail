using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour {

	private List<Rigidbody2D> _accessibleItems;
	private Rigidbody2D _grabbedItem;
	private FixedJoint2D _joint;


	private static string TagName = "Cube";

	// Use this for initialization
	void Start () {
		_accessibleItems = new List<Rigidbody2D>();
		_joint = GetComponent<FixedJoint2D>();
		_grabbedItem = GetComponent<Rigidbody2D>();
	}

	/// Update is called every frame, if the MonoBehaviour is enabled.
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space) && _accessibleItems.Count!=0){
			//Grab item
			GrabItem(_accessibleItems[0]);
		}else if(Input.GetKeyUp(KeyCode.Space) && _grabbedItem!=null){
			//Release item
			ReleaseGrabbedItem();
		}
	}
	
	/// Sent when an incoming collider makes contact with this object's
	/// collider (2D physics only).
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag==TagName){
			if(other.rigidbody!=null && !_accessibleItems.Contains(other.rigidbody)){
				_accessibleItems.Add(other.rigidbody);
			}
		}
	}

	/// Sent when a collider on another object stops touching this
	/// object's collider (2D physics only).
	void OnCollisionExit2D(Collision2D other)
	{
		if(other.gameObject.tag==TagName){
			if(_accessibleItems.Contains(other.rigidbody)){
				_accessibleItems.Remove(other.rigidbody);
			}
		}
	}

	/// Permet de déplacer l'item donné à l'aide d'un FixedJoint2D
	void GrabItem(Rigidbody2D item){
		//Activer la jointure
		_joint.enabled = true;
		//Lier la jointure à l'item passé en paramètre
		_joint.connectedBody = item;
		//Changer le type de RigidBody de Kinematic à Dynamic
		item.bodyType = RigidbodyType2D.Dynamic;
		item.freezeRotation = false;		
		_grabbedItem = item;

	}

	/// Libère l'objet capturé.
	void ReleaseGrabbedItem(){
		//Changer le type de RigidBody de Dynamic à Kinematic
		_grabbedItem.freezeRotation = true;		
		_grabbedItem.bodyType = RigidbodyType2D.Kinematic;
		//Désactiver la jointure et remettre la propriété nulle
		_joint.enabled = false;
		_grabbedItem.velocity = Vector2.zero;
		_grabbedItem = null;
	}
}
