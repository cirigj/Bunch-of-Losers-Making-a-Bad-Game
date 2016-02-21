using UnityEngine;
using System.Collections;

public static class Globals
{
    public static int BaseLives = 3;
    public static int BaseBombs = 3;
    public static int Points = 0;
    public static class Inputs
    {
        public static float Horizontal;
        public static float Vertical;
        public static bool Focus;
        public static bool Bomb;
        public static bool Fire;
    }
    static float _camWidth;
    public static float camWidth
    {
        get
        {
            setCam();
            return _camWidth;
        }
        private set { }
    }
    static float _camHeight;
    public static float camHeight
    {
        get
        {
            setCam();
            return _camHeight;
        }
        private set { }
    }
    static void setCam()
    {
        Camera cam = Camera.main;
        Globals._camHeight = 2f * cam.orthographicSize;
        Globals._camWidth = Globals._camHeight * cam.aspect;
    }
}
