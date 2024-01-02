using ECSEditor;
using UnityEditor;
internal class ECSTool
{
    [MenuItem("Tools/ECS/Generate ECS")]
    private static void Menue()
    {
        var t = System.Type.GetType("ILogicComponent");
        ECSGenerator.ECSLiteGen<ILogic>(null, "Assets/ECS/Logic/Generate/", null);
    }
}
