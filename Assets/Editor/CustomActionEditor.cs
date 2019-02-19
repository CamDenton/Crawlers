using GameFlow;
using UnityEditor;

namespace Custom {

[CustomEditor(typeof(CustomAction))]
public class CustomActionEditor : ActionEditor {

	// Declare properties exactly as defined in the Action subclass
	protected SerializedProperty _yourName;
	protected SerializedProperty _yourNameVar;

	// Action user interface
	protected override void OnActionGUI() {
		// Draws a Variable-friendly text field for the property in the Inspector
		PropertyField("Your Name", _yourName, _yourNameVar);
	}

}

}
