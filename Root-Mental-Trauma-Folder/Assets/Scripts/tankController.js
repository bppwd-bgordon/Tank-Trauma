#pragma strict
//Declare variables
var wheelFL : WheelCollider;
var wheelFR : WheelCollider;
var wheelRL : WheelCollider;
var wheelRR : WheelCollider;

var wheelFLTrans : Transform;
var wheelFRTrans : Transform;
var wheelRLTrans : Transform;
var wheelRRTrans : Transform;

var maxDriveTorque : float = 15;
var maxRotTorque : float = 25;
var decelerationSpeed : float = 30;
var rotationSpeed : float;
var currentSpeed : float;
var topSpeed : float = 50;
var maxRotSpeed : float;

function Start () {
//Re-align the tank's center of mass
rigidbody.centerOfMass.y = -0.9;
}

function Update (){
	WheelPosition();
	//Check if player is rotating
}
function FixedUpdate () {
	//initialize
	Control();	
	rotationSpeed = Input.GetAxis("Horizontal") * maxRotTorque;
}
function LateUpdate ()
{
	WheelPosition();
}

function Control (){
	currentSpeed = Mathf.Round(2*22/7*wheelFL.radius*wheelFL.rpm*60/1000);
	if (currentSpeed < topSpeed){
		wheelRR.motorTorque = maxDriveTorque * Input.GetAxis("Vertical");
		wheelRL.motorTorque = maxDriveTorque * Input.GetAxis("Vertical");
		wheelFL.motorTorque = maxDriveTorque * Input.GetAxis("Vertical");
		wheelFR.motorTorque = maxDriveTorque * Input.GetAxis("Vertical");
	}
	else{
		wheelRR.motorTorque = 0;
		wheelRL.motorTorque = 0;
		wheelFR.motorTorque = 0;
		wheelFL.motorTorque = 0;
	}
	if (Mathf.Abs(currentSpeed) > topSpeed){
		wheelRR.motorTorque = 0;
		wheelRL.motorTorque = 0;
		wheelFR.motorTorque = 0;
		wheelFL.motorTorque = 0;
	}
	if(Mathf.Abs(rotationSpeed) > maxRotSpeed){
		wheelRR.motorTorque = 0;
		wheelRL.motorTorque = 0;
		wheelFR.motorTorque = 0;
		wheelFL.motorTorque = 0;
	}
	
	
	
	if(Input.GetAxis("Vertical")){
	//If the vertical axis is pressed, remove the brakes
		wheelRR.brakeTorque = 0;
		wheelRL.brakeTorque = 0;
		wheelFR.brakeTorque = 0;
		wheelFL.brakeTorque = 0;
	}else if(Input.GetAxis("Vertical")==false && Input.GetAxis("Horizontal")==false){
	//If the vertical axis and the horizontal axis are not pressed, decelerate
		wheelRR.brakeTorque = decelerationSpeed;
		wheelRL.brakeTorque = decelerationSpeed;
		wheelFR.brakeTorque = decelerationSpeed;
		wheelFL.brakeTorque = decelerationSpeed;
	}
	//If the horizontal axis is pressed, apply torque to turn tank
	if(-Input.GetAxis("Horizontal"))
	{
		wheelRL.motorTorque = maxRotTorque * Input.GetAxis("Horizontal");
		wheelFL.motorTorque = maxRotTorque * Input.GetAxis("Horizontal");
		wheelRR.motorTorque = maxRotTorque * -Input.GetAxis("Horizontal");
		wheelFR.motorTorque = maxRotTorque * -Input.GetAxis("Horizontal");
	}
	
	transform.Rotate(0,rotationSpeed,0);
}

function WheelPosition (){
var hit : RaycastHit;
var wheelPos : Vector3;
	//===========Front Left Wheel
	//If the wheel is hitting the ground, make the wheel bounce
	if (Physics.Raycast(wheelFL.transform.position, -wheelFL.transform.up,hit,wheelFL.radius + wheelFL.suspensionDistance) ){
		wheelPos = hit.point+wheelFL.transform.up * wheelFL.radius;
	}
	//if not, reset the wheel's position
	else{
		wheelPos = wheelFL.transform.position -wheelFL.transform.up * wheelFL.suspensionDistance;
	}
	//Set the wheel model to the required position every frame
	wheelFLTrans.position = wheelPos;
	
	
	//===========Front Right Wheel
	if (Physics.Raycast(wheelFR.transform.position, -wheelFR.transform.up,hit,wheelFR.radius + wheelFR.suspensionDistance) ){
		wheelPos = hit.point+wheelFR.transform.up * wheelFR.radius;
	}
	else{
		wheelPos = wheelFR.transform.position -wheelFR.transform.up * wheelFR.suspensionDistance;
	}
	//Set the wheel model to the required position every frame
	wheelFRTrans.position = wheelPos;
	
	
	//===========Rear Left Wheel
	//If the wheel is hitting the ground, make the wheel bounce
	if (Physics.Raycast(wheelRL.transform.position, -wheelRL.transform.up,hit,wheelRL.radius + wheelRL.suspensionDistance) ){
		wheelPos = hit.point+wheelRL.transform.up * wheelRL.radius;
	}
	//if not, reset the wheel's position
	else{
		wheelPos = wheelRL.transform.position -wheelRL.transform.up * wheelRL.suspensionDistance;
	}
	//Set the wheel model to the required position every frame
	wheelRLTrans.position = wheelPos;
	
	
	//===========Rear Right Wheel
	//If the wheel is hitting the ground, make the wheel bounce
	if (Physics.Raycast(wheelRR.transform.position, -wheelRR.transform.up,hit,wheelRR.radius + wheelRR.suspensionDistance) ){
		wheelPos = hit.point+wheelRR.transform.up * wheelRR.radius;
	}
	//if not, reset the wheel's position
	else{
		wheelPos = wheelRR.transform.position -wheelRR.transform.up * wheelRR.suspensionDistance;
	}
	//Set the wheel model to the required position every frame
	wheelRRTrans.position = wheelPos;
}