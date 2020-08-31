using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalReferences
{
    public const string player = "Player";
    public const string collider = "EatCollider";
    public const string bound = "Bound";
    public const string visionLight = "VisionLight";
    public const string canvas = "Canvas";
    public enum TYPEOF_ASSETS { buff, sfx, music };
    public class InputReferences
    {
        public const string InputHorizontal = "Horizontal";
        public const string InputVerticle = "Vertical";
        public const KeyCode Spacebar = KeyCode.Space;
        public const KeyCode Escape = KeyCode.Escape;
    }

    public class PathReferences
    {
        public const string UI_BuffPath = "UI/Buff/";
    }

    public class UIReferences
    {
        public const string UIAtlas = "UIAtlas";
        public const string fastIconBuff = "fastBuff_Icon";
        public const string slowIconBuff = "slowBuff_Icon";
        public const string shieldIconBuff = "shieldBuff_Icon";
        public const string bonusIconBuff = "bonusBuff_Icon";
        public const string hungerIconBuff = "hungerBuff_Icon";
        public const string visionIconBuff = "visionBuff_Icon";
    }
}

