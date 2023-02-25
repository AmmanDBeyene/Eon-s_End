using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using UnityEditor;
using UnityEngine;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

using Slider = UnityEngine.UIElements.Slider;
using Toggle = UnityEngine.UIElements.Toggle;

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

        public static List<VisualElement> FindAll(this VisualElement ve, Type type)
        {
            List<VisualElement> list = new List<VisualElement>();
            ve.FindElementsByType(list, type);
            return list;
        }

        public static VisualElement FindElementByName(this VisualElement ve, string name)
        {
            if (name == null)
            {
                return ve;
            }

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

        public static VisualElement FindElementByType(this VisualElement ve, Type type)
        {
            // null case
            if (ve == null)
            {
                return null;
            }

            // base case
            if (ve.GetType() == type)
            {
                return ve;
            }

            // start recursively looking through all children
            foreach (VisualElement child in ve.Children())
            {
                VisualElement result = child.FindElementByType(type);

                // if the result is not null we have successfully found our element
                if (result != null)
                {
                    return result;
                }
            }

            // recursive child search unsuccessful. 
            return null;
        }

        private static void FindElementsByType(this VisualElement ve, List<VisualElement> result, Type type)
        {
            // null case
            if (ve == null)
            {
                return;
            }

            // base case
            if (ve.GetType() == type)
            {
                if (result.Contains(ve))
                {
                    return;
                }

                result.Add(ve);
                return;
            }

            // start recursively looking through all children
            foreach (VisualElement child in ve.Children())
            {
                child.FindElementsByType(result, type);
            }
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
            return new Vector3(ve.contentRect.width, ve.contentRect.height, 0.0f);
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

        #region Field Getter Shortcuts

        public static string GetTextFieldValue(this VisualElement ve, string name)
        {
            return ((TextField)ve.Find(name)).text;
        }

        public static void SetTextFieldValue(this VisualElement ve, string name, string value)
        {
            ((TextField)ve.Find(name)).value = value;
        }

        public static UnityEngine.Object GetObjectFieldValue(this VisualElement ve, string name)
        {
            return ((ObjectField)ve.Find(name)).value;
        }
        
        public static void SetObjectFieldValue(this VisualElement ve, string name, UnityEngine.Object value)
        {
            ((ObjectField)ve.Find(name)).value = value;
        }


        public static string GetRadioButtonGroupValue(this VisualElement ve, string name)
        {
            RadioButtonGroup group = ((RadioButtonGroup)ve.Find(name));
            return group.choices.ToList()[group.value];
        }

        public static void SetRadioButtonGroupValue(this VisualElement ve, string name, string value)
        {
            RadioButtonGroup group = ((RadioButtonGroup)ve.Find(name));
            int index = group.choices.ToList().IndexOf(value);
            group.value = index;
        }

        public static bool GetToggleValue(this VisualElement ve, string name)
        {
            return ((Toggle)ve.Find(name)).value;
        }

        public static void SetToggleValue(this VisualElement ve, string name, bool value)
        {
            ((Toggle)ve.Find(name)).value = value;
        }

        public static float GetSliderValue(this VisualElement ve, string name)
        {
            return ((Slider)ve.Find(name)).value;
        }

        public static void SetSliderValue(this VisualElement ve, string name, float value)
        {
            ((Slider)ve.Find(name)).value = value;
        }

        public static int GetIntSliderValue(this VisualElement ve, string name)
        {
            return ((SliderInt)ve.Find(name)).value;
        }

        public static void SetIntSliderValue(this VisualElement ve, string name, int value)
        {
            ((SliderInt)ve.Find(name)).value = value;
        }

        public static string GetDropdownValue(this VisualElement ve, string name)
        {
            return ((DropdownField)ve.Find(name)).value;
        }

        public static void SetDropdownValue(this VisualElement ve, string name, string value)
        {
            ((DropdownField)ve.Find(name)).value = value;
        }

        public static int GetIntFieldValue(this VisualElement ve, string name)
        {
            return ((IntegerField)ve.Find(name)).value;
        }

        public static void SetIntFieldValue(this VisualElement ve, string name, int value)
        {
            ((IntegerField)ve.Find(name)).value = value;
        }

        public static float GetFloatFieldValue(this VisualElement ve, string name)
        {
            return ((FloatField)ve.Find(name)).value;
        }

        public static void SetFloatFieldValue(this VisualElement ve, string name, float value)
        {
            ((FloatField)ve.Find(name)).value = value;
        }

        public static long GetLongFieldValue(this VisualElement ve, string name)
        {
            return ((LongField)ve.Find(name)).value;
        }

        public static void SetLongFieldValue(this VisualElement ve, string name, long value)
        {
            ((LongField)ve.Find(name)).value = value;
        }

        public static Vector2 GetVector2FieldValue(this VisualElement ve, string name)
        {
            return ((Vector2Field)ve.Find(name)).value;
        }

        public static void SetVector2FieldValue(this VisualElement ve, string name, Vector2 value)
        {
            ((Vector2Field)ve.Find(name)).value = value;
        }

        public static Vector3 GetVector3FieldValue(this VisualElement ve, string name)
        {
            return ((Vector3Field)ve.Find(name)).value;
        }

        public static void SetVector3FieldValue(this VisualElement ve, string name, Vector3 value)
        {
            ((Vector3Field)ve.Find(name)).value = value;
        }

        public static Vector4 GetVector4FieldValue(this VisualElement ve, string name)
        {
            return ((Vector4Field)ve.Find(name)).value;
        }

        public static void SetVector4FieldValue(this VisualElement ve, string name, Vector4 value)
        {
            ((Vector4Field)ve.Find(name)).value = value;
        }

        public static Rect GetRectFieldValue(this VisualElement ve, string name)
        {
            return ((RectField)ve.Find(name)).value;
        }

        public static void SetRectFieldValue(this VisualElement ve, string name, Rect value)
        {
            ((RectField)ve.Find(name)).value = value;
        }

        public static Bounds GetBoundsFieldValue(this VisualElement ve, string name)
        {
            return ((BoundsField)ve.Find(name)).value;
        }

        public static void SetBoundsFieldValue(this VisualElement ve, string name, Bounds value)
        {
            ((BoundsField)ve.Find(name)).value = value;
        }

        public static Color GetColorFieldValue(this VisualElement ve, string name)
        {
            return ((ColorField)ve.Find(name)).value;
        }

        public static void SetColorFieldValue(this VisualElement ve, string name, Color value)
        {
            ((ColorField)ve.Find(name)).value = value;
        }
        
        public static AnimationCurve GetCurveFieldValue(this VisualElement ve, string name)
        {
            return ((CurveField)ve.Find(name)).value;
        }

        public static void SetCurveFieldValue(this VisualElement ve, string name, AnimationCurve value)
        {
            ((CurveField)ve.Find(name)).value = value;
        }

        public static Gradient GetGradientFieldValue(this VisualElement ve, string name)
        {
            return ((GradientField)ve.Find(name)).value;
        }

        public static void SetGradientFieldValue(this VisualElement ve, string name, Gradient value)
        {
            ((GradientField)ve.Find(name)).value = value;
        }

        public static Enum GetEnumFieldValue(this VisualElement ve, string name)
        {
            return ((EnumField)ve.Find(name)).value;
        }

        public static void SetEnumFieldValue(this VisualElement ve, string name, Enum value)
        {
            ((EnumField)ve.Find(name)).value = value;
        }

        public static string GetTagFieldValue(this VisualElement ve, string name)
        {
            return ((TagField)ve.Find(name)).value;
        }

        public static void SetTagFieldValue(this VisualElement ve, string name, string value)
        {
            ((TagField)ve.Find(name)).value = value;
        }

        public static string GetMaskFieldValue(this VisualElement ve, string name)
        {
            MaskField mf = (MaskField)ve.Find(name);
            return mf.choices[mf.value];
        }

        public static void SetMaskFieldValue(this VisualElement ve, string name, string value)
        {
            MaskField mf = ((MaskField)ve.Find(name));
            int index = mf.choices.ToList().IndexOf(value);
            mf.value = index;
        }

        public static int GetLayerFieldValue(this VisualElement ve, string name)
        {
            LayerField lf = (LayerField)ve.Find(name);
            return lf.choices[lf.value];
        }

        public static void SetLayerFieldValue(this VisualElement ve, string name, int value)
        {
            LayerField lf = ((LayerField)ve.Find(name));
            int index = lf.choices.ToList().IndexOf(value);
            lf.value = index;
        }

        public static string GetLayerMaskFieldValue(this VisualElement ve, string name)
        {
            LayerMaskField lmf = (LayerMaskField)ve.Find(name);
            return lmf.choices[lmf.value];
        }

        public static void SetLayerMaskFieldValue(this VisualElement ve, string name, string value)
        {
            LayerMaskField lmf = ((LayerMaskField)ve.Find(name));
            int index = lmf.choices.ToList().IndexOf(value);
            lmf.value = index;
        }

        // Lord have mecry on my wrists
        // Lord have mercy on my wrists ...

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

        #region Vector3 

        public static bool HasNan(this Vector3 vec)
        {
            return float.IsNaN(vec.x) || float.IsNaN(vec.y) || float.IsNaN(vec.z);
        }

        #endregion

        #region string

        public static string ToLiteral(this string input)
        {
            return Regex.Escape(input);
        }

        #endregion
    }
}
