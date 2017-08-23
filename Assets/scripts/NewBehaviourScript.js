#pragma strict
  
function Start () {
    
}

function Update () {
	
}
  var explosionRadius : float = 5.0;

	function OnDrawGizmosSelected () {
		// Display the explosion radius when selected
		Gizmos.color = Color.white;
		Gizmos.DrawSphere (transform.position, explosionRadius);
	}