// Make sure this script is saved inside a folder called "Editor" in you projects Assets folder. Otherwise you'll recieve errors when trying to create a build opf your game.

using UnityEditor;            // Allows us access to methods that can make edits inside the Unity Editor.

// This class will be used to read the Material Types we created for the 'FMODStudioFirstPersonFootsteps' script, and then add them as options to select within a dropdown menu on the 'FMODStudioMaterialSetter' script. It will also read which material type we set for each surface the player can walk on and set the 'MaterialValue' variable to the value used to represent that type.
[CustomEditor(typeof(FMODMaterialSetter))]                                                               // Using this Attribute, we can set which script we want to make edits to inside the Editor.
public class FMODStudioFootstepsEditor : Editor                                                                // Because this script won't be attached to a component, we don't want to derive from the 'Monobehaviour' class. Because we want it to edit an already exisiting script, we want it to derive from the 'Editor' class instead.
{
    public override void OnInspectorGUI()                                                                      // Unity uses this method to display fileds and variables for our scripts inside Unity's Editor in the Inspector tab. By including the keyword 'override' we're saying that we want to not display all of the variables for the 'MaterialSetter' script that normally would be, and instead display whatever we put inside this method. It runs, whenever a change to the object in question has been made via the inspector tab.
    {
        var MS = target as FMODMaterialSetter;                                                           // We need to access our 'MaterialSetter' scripts to edit it. So we create a variable called MS and by using 'target' we can target any instances of a script that this class is editing. In our case, it's the 'MaterialSetter' script (remember we set this in the "CustomEditor" attribute). We can now access the 'MaterialSetter' script attached to our surfaces and the variables inside of them using MS.
        var FPF = FindObjectOfType<FMODPlayerAudio>();                                          // We create a variable called FPF to read variables from it. Unfortuantly, because we're not editing this script in this class, we can't use 'target' to find it. So instead we use 'FindObjectOfType' instead.

        MS.MaterialValue = EditorGUILayout.Popup("Set Material As", MS.MaterialValue, FPF.m_materialTypes);      // 'EditorGUILayout.Popup' creates a dropdown menu inside our inspector tab for us to use to set the material of the surface we're editing. We give it 3 arguments. The first is a string that simply labels it. The second is an int value that our menu will show us in the inspector as selected. The third is a range of string options for us to select. At the beginning of this line, we're setting our 'MaterialValue' variable to match the result of whatever option we select in this menu when we next interact with then inspector tab.
    }
}
