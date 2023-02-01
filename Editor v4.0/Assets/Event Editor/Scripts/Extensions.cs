using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Event_Editor.Scripts
{
    public static class Extensions
    {
        #region VisualElement
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

        public static bool Overlaps(this VisualElement first, VisualElement second)
        {
            Rect globalFirst = first.LocalToWorld(first.contentRect);
            Rect globalSecond = second.LocalToWorld(second.contentRect);

            return globalFirst.Overlaps(globalSecond);
        }

        public static bool Contains(this VisualElement ve, Vector2 globalPoint)
        {
            if (ve == null)
            {
                return false;
            }

            Rect globalRect = ve.LocalToWorld(ve.contentRect);
            return globalRect.Contains(globalPoint);
        }


        public static Vector3 Size(this VisualElement ve)
        {
            return new Vector3(ve.layout.width, ve.layout.height, 0.0f);
        }

        public static float Height(this VisualElement ve)
        {
            return ve.Size().y;
        }

        public static float Width(this VisualElement ve)
        {
            return ve.Size().x;
        }
        public static Vector3 GlobalDistanceTo(this VisualElement origin, VisualElement target)
        {
            return origin.GlobalDistanceTo(target.GlobalPosition());
        }

        public static Vector3 GlobalDistanceTo(this VisualElement origin, Vector3 globalPosition)
        {
            return origin.GlobalPosition() - globalPosition;
        }

        public static Vector3 GlobalPosition(this VisualElement ve)
        {
            return ve.LocalToWorld(Vector3.zero);
        }

        public static Vector3 GlobalCenter(this VisualElement ve)
        {
            return ve.GlobalPosition() + ve.Size() * 0.5f;
        }

        public static Vector3 LocalPosition(this VisualElement ve)
        {
            return ve.transform.position;
        }

        #endregion

        #region IStyle

        public static void BorderWidth(this IStyle style, StyleFloat width)
        {
            style.borderBottomWidth = width;
            style.borderLeftWidth = width;
            style.borderRightWidth = width;
            style.borderTopWidth = width;
        }

        public static void BorderColor(this IStyle style, StyleColor color)
        {
            style.borderBottomColor = color;
            style.borderLeftColor = color;
            style.borderRightColor = color;
            style.borderTopColor = color;
        }

        public static void BorderRadius(this IStyle style, StyleLength radius)
        {
            style.borderBottomLeftRadius = radius;
            style.borderBottomRightRadius = radius;
            style.borderTopLeftRadius = radius;
            style.borderTopRightRadius = radius;
        }

        #endregion

        #region List<Block>

        public static void Delete(this List<Block> blocks, VisualElement ve)
        {
            Block toRemove = blocks.Find(i => i.visualElement == ve);

            if (toRemove == null)
            {
                return;
            }

            toRemove.Delete();
        }

        #endregion

        #region BlockType 

        public static PipeType ToPipeType(this BlockType blockType)
        {
            return blockType == BlockType.Command ? PipeType.Command : PipeType.Condition;
        }

        public static BlockType ToBlockType(this PipeType pipeType)
        {
            return pipeType == PipeType.Command ? BlockType.Command : BlockType.Condition;
        }

        #endregion
    }
}
