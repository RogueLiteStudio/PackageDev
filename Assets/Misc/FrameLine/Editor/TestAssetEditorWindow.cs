using FrameLine;
using UnityEditor;
[EditorWindowTitle(title = "Test Asset Editor")]
public class TestAssetEditorWindow : TFrameLineWindow<TestAsset>
{
    [MenuItem("Tools/´´½¨FrameLine")]
    static void CreateAsset()
    {
        string path = "Assets/FrameLine/TestAsset.asset";
        var asset = AssetDatabase.LoadAssetAtPath<TestAsset>(path);
        if (asset == null)
        {
            asset = CreateInstance<TestAsset>();
            var group = FrameLineUtil.CreateGroup(asset);
            group.FrameCount = 100;
            FrameLineUtil.CreateAction(group, typeof(TestEffect), 0, 5);
            FrameLineUtil.CreateAction(group, typeof(TestEffect), 1, 8);
            FrameLineUtil.CreateAction(group, typeof(TestEffect), 2, 10);

            FrameLineUtil.CreateAction(group, typeof(TestAudio), 0, 5);
            FrameLineUtil.CreateAction(group, typeof(TestAudio), 1, 8);
            FrameLineUtil.CreateAction(group, typeof(TestAudio), 2, 10);

            AssetDatabase.CreateAsset(asset, path);
            AssetDatabase.SaveAssets();
        }
        OpenAsset(asset);
    }
}
