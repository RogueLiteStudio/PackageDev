using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class VisualElementWindow : EditorWindow
{
    [MenuItem("Tools/VisualElementWindow")]
    static void ShowWindow()
    {
        GetWindow<VisualElementWindow>();
    }
    public void CreateGUI()
    {
        var rootScroll = new VisualElement();
        rootScroll.style.flexDirection = FlexDirection.Column;
        rootScroll.style.backgroundColor = Color.gray;
        for (int i=0; i<5; ++i)
        {
            var child = new VisualElement();
            child.style.backgroundColor = Color.green;
            child.style.minHeight = 20;
            child.style.marginTop = 10;
            rootScroll.Add(child);
            int childCount = i / 2;
            var container = new VisualElement();
            container.style.backgroundColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
            container.style.top = 1;
            container.style.bottom = 1;
            container.style.left = 0;
            container.style.right = 0;
            container.style.flexDirection = FlexDirection.Column;
            child.Add(container);
            for (int j=0; j<childCount; ++j)
            {
                var c = new VisualElement();
                c.style.backgroundColor = Color.blue;
                c.style.height = 10;
                c.style.marginTop = 5;
                container.Add(c);
            }
        }
        var btn = new Button();
        btn.text = "Fold";
        btn.clicked += () =>
        {
            var children = rootScroll.Children();
            foreach (var child in children)
            {
                if (child.childCount == 0)
                    continue;
                var c = child.ElementAt(0);
                float height = child.contentRect.height;
                bool isVisible = c.style.display == DisplayStyle.Flex;
                c.style.display = isVisible ? DisplayStyle.None : DisplayStyle.Flex;
                Debug.Log($"{height} --> {child.contentRect.height}");
            }
        };

        rootScroll.Add(btn);
        rootVisualElement.Add(rootScroll);
        rootScroll.StretchToParentSize();
    }
}
