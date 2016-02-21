using UnityEngine;
using System.Collections;

public static class Globals
{
    public static int BaseLives = 3;
    public static int Points = 0;
    public static class Inputs
    {
        public static float Horizontal;
        public static float Vertical;
        public static bool Focus;
        public static bool Bomb;
        public static bool Fire;
    }
    public static float camWidth
    {
        get
        {
            Camera cam = Camera.main;
            return 2f * cam.orthographicSize * cam.aspect;
        }
        private set { }
    }
    public static float camHeight
    {
        get
        {
            Camera cam = Camera.main;
            return 2f * cam.orthographicSize;
        }
        private set { }
    }
}
