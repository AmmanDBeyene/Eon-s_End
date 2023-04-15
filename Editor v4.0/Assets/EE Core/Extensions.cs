using EECore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

namespace EECore
{
    public static class Extensions
    {
        public static Vector3 ToVector3(this Direction d)
        {
            switch (d)
            {
                case Direction.Up:
                    return Vector3.forward;
                case Direction.Down:
                    return Vector3.back;
                case Direction.Left:
                    return Vector3.left;
                case Direction.Right:
                    return Vector3.right;
            }

            return Vector3.zero;
        }

        public static int ToInt(this Direction d)
        {
            switch (d)
            {
                case Direction.Up:
                    return 0;
                case Direction.Right:
                    return 1;
                case Direction.Down:
                    return 2;
                case Direction.Left:
                    return 3;
            }

            return 0;
        }

        public static Direction ToDirection(this int i)
        {
            switch (i)
            {
                case 0:
                    return Direction.Up;
                case 1:
                    return Direction.Right;
                case 2:
                    return Direction.Down;
                case 3:
                    return Direction.Left;
            }

            return Direction.Up;
        }

        public static Direction ToDirection(this KeyCode kc)
        {
            switch (kc)
            {
                case KeyCode.UpArrow:
                    return Direction.Up;
                case KeyCode.RightArrow:
                    return Direction.Right;
                case KeyCode.DownArrow:
                    return Direction.Down;
                case KeyCode.LeftArrow:
                    return Direction.Left;
            }

            return Direction.Up;
        }

        public static Direction Opposite(this Direction d)
        {
            switch (d)
            {
                case Direction.Up:
                    return Direction.Down;
                case Direction.Right:
                    return Direction.Left;
                case Direction.Down:
                    return Direction.Up;
                case Direction.Left:
                    return Direction.Right;
            }
            return Direction.Up;
        }

        public static bool IsOpposite(this Direction d, Direction rhs)
        {
            return rhs == d.Opposite();
        }

        public static RaycastHit Cast(Vector3 start, Vector3 end)
        {
            RaycastHit hit;
            Vector3 dir = (end - start).normalized;
            float range = (start - end).magnitude;

            Debug.DrawLine(start, end, Color.red, range);

            Physics.Raycast(start, dir, out hit, range);

            return hit;
        }

        public static bool BasicMatches(this CharacterFilterType filter, CharacterType type)
        {
            switch (filter)
            {
                case CharacterFilterType.Enemy:
                    return type == CharacterType.Enemy;
                case CharacterFilterType.Ally:
                    return type == CharacterType.Ally;
                case CharacterFilterType.Any:
                    return true;
                case CharacterFilterType.None:
                    return false;
            }

            return false;
        }

        public static int CornerType(this Direction d, Direction rhs)
        {
            if ((d == Direction.Up && rhs == Direction.Right)
                || d == Direction.Left && rhs == Direction.Down)
            {
                return 0;
            }

            if ((d == Direction.Up && rhs == Direction.Left)
                || d == Direction.Right && rhs == Direction.Down)
            {
                return 1;
            }

            if ((d == Direction.Right && rhs == Direction.Up)
                || d == Direction.Down && rhs == Direction.Left)
            {
                return 2;
            }

            if ((d == Direction.Down && rhs == Direction.Right)
                || d == Direction.Left && rhs == Direction.Up)
            {
                return 3;
            }

            return 0;
        }

        public static int End<T>(this List<T> list)
        {
            return list.Count - 1;
        }

        public static T Last<T>(this List<T> list)
        {
            return list[list.End()];
        }

        public static void RoundXZ(this ref Vector3 vec)
        {
            vec.Set(vec.x.Round(), vec.y, vec.z.Round());
        }

        public static float Round(this float value)
        {
            return (float)Math.Round(value * 2, MidpointRounding.AwayFromZero) / 2.0f;
        } 
    }
}
