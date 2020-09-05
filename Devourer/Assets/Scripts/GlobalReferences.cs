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
    public const string highScore = "High Score";
    public const string score = "Score";
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
        public const string BGMPath = "Audio/BGM";
        public const string SFXPath = "Audio/SFX";
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

    public class BGMReferences
    {
        public const string MainMenu = "Main Menu";
        public const string Gameplay = "Gameplay";
        public const string Ending = "Ending";
        public const string Setting = "Setting";
    }

    public class SFXReferences{
        public const string Eat = "Eat";
        public const string ButtonOnClick = "Button";
    }
}

