/*@CustomEditor()
class PlayerEditor extends Editor 
{
	private var showColliders : boolean = true;
	private var showTrans : boolean = true;
	private var showSpeeds : boolean = true;
	function OnInspectorGUI() 
	{
		showColliders = EditorGUILayout.Foldout(showColliders, "Wheel Colliders");
		showTrans = EditorGUILayout.Foldout(showTrans, "Wheel Transforms");
		showSpeeds = EditorGUILayout.Foldout(showSpeeds, "Physics Values");
		
		if(showColliders) {
			target.wheelFL = EditorGUILayout.ObjectField("wheelFL", target.wheelFL);
			target.wheelFR = EditorGUILayout.ObjectField("wheelFR", target.wheelFR);
			target.wheelRL = EditorGUILayout.ObjectField("wheelRL", target.wheelRL);
			target.wheelRR = EditorGUILayout.ObjectField("wheelRR", target.wheelRR);
		}
		
		if(showColliders) {
			target.wheelFL = EditorGUILayout.ObjectField("wheelFL", target.wheelFL);
			target.wheelFR = EditorGUILayout.ObjectField("wheelFR", target.wheelFR);
			target.wheelRL = EditorGUILayout.ObjectField("wheelRL", target.wheelRL);
			target.wheelRR = EditorGUILayout.ObjectField("wheelRR", target.wheelRR);
		}
	}
}*/