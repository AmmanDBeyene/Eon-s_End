using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine.UIElements;

namespace Assets.Event_Editor.Scripts
{
    public static class Extensions
    {
        public static VisualElement AddCreate(this VisualElement ve, string path)
        {
            VisualElement loaded = Create(path);
            ve.Add(loaded);
            return loaded;
        }

        public static VisualElement Create(string path)
        {
            VisualTreeAsset uiAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(path);
            VisualElement ui = uiAsset.Instantiate();
            return ui;
        }

        public static VisualTreeAsset Load(string path)
        {
            return AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(path);
        }

        public static VisualElement Find(this VisualElement ve, string name)
        {
            return FindElementByName(ve, name);
        }

        public static VisualElement FindElementByName(this VisualElement ve, string name)
        {
            // null case
            if (ve == null)
            {
                return null;
            }

            // base case
            if (ve.name == name)
            {
                return ve;
            }

            // start recursively looking through all children
            foreach (VisualElement child in ve.Children())
            {
                VisualElement result = child.FindElementByName(name);

                // if the result is not null we have successfully found our element
                if (result != null)
                {
                    return result;
                }
            }

            // recursive child search unsuccessful. 
            return null;
        }

        public static VisualElement Add(this VisualElement ve, string path)
        {
            VisualTreeAsset uiAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(path);
            VisualElement ui = uiAsset.CloneTree();
            ve.Add(ui);
            return ui;
        }

    }
}
