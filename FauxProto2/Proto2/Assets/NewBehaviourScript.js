var other : GameObject;
var gravity : float = 100;
var startingVelocity : Vector3 = Vector3.up;
private var distSqr : float;     
private var force : float;
private var dir : Vector3;
private var orbitPoints : Vector3[];
var maxCount : int = 10000;
var simplify : int = 5;
private var privateMaxCount : int;
var lineRenderer : LineRenderer;
var RB : Rigidbody;
var DeivitFaux;
 
function Start () {
    privateMaxCount = maxCount;
    orbitPoints = new Vector3[privateMaxCount];
    
    //lineRenderer.SetWidth(2,2);
   
    
    startingVelocity = RB.velocity;
}

function Update(){
    if(Input.GetKeyDown(KeyCode.M)){
        ComputeTrajectory();
    }
}
 
function ComputeTrajectory () {
    dir = (other.transform.position - transform.position);
    var angle : float = 0;
    var dt : float = Time.fixedDeltaTime;
    var s : Vector3 = transform.position - other.transform.position;
    var lastS : Vector3 = s;
    var v : Vector3 = RB.velocity;
    var a : Vector3 = dir.normalized*gravity/dir.sqrMagnitude;
    var d : Vector3 = dir;
    var tempAngleSum : float = 0;
    var step : int = 0;
    while(angle < 360 && step < privateMaxCount*simplify){
        if(step % simplify == 0){
            orbitPoints[step/simplify] = s+other.transform.position;
            angle += tempAngleSum;
            tempAngleSum = 0;
        }
        d = -s;
        a = d.normalized*gravity/d.sqrMagnitude;
        v += a*dt;
        s += v*dt;
        tempAngleSum += Mathf.Abs(Vector3.Angle(s, lastS));
        lastS = s;
        step ++;
    }
    lineRenderer.SetVertexCount(step/simplify);
    for(var i : int = 0; i < step/simplify; i++){
        lineRenderer.SetPosition(i, orbitPoints[i]);
    }
}