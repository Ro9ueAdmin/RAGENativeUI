namespace RAGENativeUI
{
    using Rage;
    using static Rage.Native.NativeFunction;

    internal static class N
    {
        public static void GetHudColour(int colorId, out int r, out int g, out int b, out int a) => Natives.x7C9C91AB74A0360F(colorId, out r, out g, out b, out a);
        public static void SetHudColour(int colorId, int r, int g, int b, int a) => Natives.xF314CF4F0211894E(colorId, r, g, b, a);

        public static void PlaySoundFrontend(int soundId, string soundSet, string soundName, bool p3) => Natives.x67C540AA08E4A6F5(soundId, soundName, soundSet, p3);

        public static bool IsControlJustPressed(int group, int control) => Natives.x580417101DDB492F<bool>(group, control);
        public static bool IsDisabledControlJustPressed(int group, int control) => Natives.x91AEF906BCA88877<bool>(group, control);
        public static bool IsControlPressed(int group, int control) => Natives.xF3A21BCD95725A4A<bool>(group, control);
        public static bool IsDisabledControlPressed(int group, int control) => Natives.xE2587F8CBBD87B1D<bool>(group, control);
        public static void DisableAllControlActions(int group) => Natives.x5F4B6931816E599B(0);
        public static void EnableControlAction(int group, int control, bool enable) => Natives.x351220255D64C155(group, control, enable);
        public static string GetControlInstructionalButton(int group, int control, int p2) => Natives.x0499D7B09FC9B407<string>(group, control, p2);

        public static void SetStreamedTextureDictAsNoLongerNeeded(string textureDict) => Natives.xBE2CACCF5A8AA805(textureDict);
        public static void RequestStreamedTextureDict(string textureDict, bool p1) => Natives.xDFA2EF8E04127DD5(textureDict, p1);
        public static bool HasStreamedTextureDictLoaded(string textureDict) => Natives.x0145F696AAAAD2E4<bool>(textureDict);

        public static void DrawTriangle3D(Vector3 p1, Vector3 p2, Vector3 p3, int r, int g, int b, int a, string textureDict, string textureName, Vector3 uv1, Vector3 uv2, Vector3 uv3)
            => Natives.x29280002282F1928(p1, p2, p3, r, g, b, a, textureDict, textureName, uv1, uv2, uv3);
        public static void DrawTriangle3D(Vector3 v1, Vector3 v2, Vector3 v3, int r, int g, int b, int a)
            => Natives.x29280002282F1928(v1, v2, v3, r, g, b, a, 0, 0);

        public static void DrawSprite(string textureDict, string textureName, float x, float y, float width, float height, float rotation, int r, int g, int b, int a)
            => Natives.xE7FFAE5EBF23D890(textureDict, textureName, x, y, width, height, rotation, r, g, b, a);

        public static void DrawRect(float x, float y, float width, float height, int r, int g, int b, int a) => Natives.x3A618A217E5154F0(x, y, width, height, r, g, b, a);

        public static void AddTextComponentSubstringPlayerName(string text) => Natives.x6C188BE134E074AA(text);
        public static void SetTextFont(int font) => Natives.x66E0276CC5F6B9DA(font);
        public static void SetTextScale(float scale, float size) => Natives.x07C837F9A01C34C9(scale, size);
        public static void SetTextColour(int r, int g, int b, int a) => Natives.xBE6B23FFA53FB442(r, g, b, a);
        public static void SetTextDropShadow() => Natives.x1CA3E9EAC9D93E5E();
        public static void SetTextDropshadow(int distance, int r, int g, int b, int a) => Natives.x465C84BC39F1C351(distance, r, g, b, a);
        public static void SetTextOutline() => Natives.x2513DFB0FB8400FE();

        /// <param name="type">
        /// <para>0: Center-Justify</para>
        /// <para>1: Left-Justify</para>
        /// <para>2: Right-Justify, requires SET_TEXT_WRAP, otherwise it will draw to the far right of the screen.</para>
        /// </param>
        public static void SetTextJustification(int type) => Natives.x4E096588B13FFECA(type);
        /// <summary>
        /// It sets the text in a specified box and wraps the text if it exceeds the boundaries.
        /// Both values are for X axis. Useful when positioning text set to center or aligned to the right.  
        /// </summary>
        /// <param name="start">Left boundary on screen position (0.0 - 1.0).</param>
        /// <param name="end">Right boundary on screen position (0.0 - 1.0).</param>
        public static void SetTextWrap(float start, float end) => Natives.x63145D9C883A1A70(start, end);
        public static void BeginTextCommandDisplayText(string format) => Natives.x25FBB336DF1804CB(format);
        public static void EndTextCommandDisplayText(float x, float y) => Natives.xCD015E5BB0D96A57(x, y);
        public static float GetTextScaleHeight(float scale, int font) => Natives.xDB88A37483346780<float>(scale, font);

        public static float GetSafeZoneSize() => Natives.xBAF107B6BB2C97F0<float>();

        public static void HideHudComponentThisFrame(int id) => Natives.x6806C51AD12B83B8(id);

        public static void StopAllScreenEffects() => Natives.xB4EDDC19532BFB85();

        // Same as GET_SCREEN_RESOLUTION (0x888D57E407E63624) 
        public static void GetScreenResolution(out int x, out int y) { x = 1280; y = 720; }
        // Same as _GET_ACTIVE_SCREEN_RESOLUTION (0x873C9F3104101DD3)
        public static void GetActiveScreenResolution(out int x, out int y)
        {
            System.Drawing.Size r = Game.Resolution;
            x = r.Width;
            y = r.Height;
        }
        public static float GetAspectRatio(bool b) => Natives.xF1307EF624A80D87<float>(b);
        public static bool GetIsWidescreen() => Natives.x30CF4BDA4FCB1905<bool>();


        /// <summary>
        /// This function anchors script draws to a side of the safe zone. This needs to be called to make the interface independent of the player's safe zone configuration.
        /// </summary>
        /// <param name="alignX">
        /// The horizontal alignment. This can be 67 ('C'), 76 ('L'), or 82 ('R').
        /// <para>
        /// C (67) - Center: DRAW_TEXT starts in the middle of the screen, while DRAW_RECT starts on the right; both move with the right side of the screen.
        /// </para>
        /// <para>
        /// L (76) - Left: Anchors to the left side, DRAW_RECT starts on the left side of the screen, same as DRAW_TEXT when centered.
        /// </para>
        /// <para>
        /// R (82) - Right: DRAW_TEXT starts on the left side(normal 0,0), while DRAW_RECT starts some short distance away from the right side of the screen, both move with the right side of the screen.
        /// </para>
        /// </param>
        /// <param name="alignY">
        /// The vertical alignment.This can be 67 ('C'), 66 ('B'), or 84 ('T').
        /// <para>
        /// B (66) - Bottom: DRAW_RECT starts about as far as the middle of the map from the bottom, while DRAW_TEXT is about rather centered.
        /// </para>
        /// <para>
        /// C (67) - Center: It starts at a certain distance from the bottom, but the distance is fixed, the distance is different from 66.
        /// </para>
        /// <para>
        /// T (84) - Top: Anchors to the top, DRAW_RECT starts on the top of the screen, DRAW_TEXT just below it.
        /// </para>
        /// </param>
        /// <remarks>
        /// Using any other value (including 0) will result in the safe zone not being taken into account for this draw. The canonical value for this is 'I' (73).
        /// </remarks>
        public static void SetScriptGfxAlign(char alignX, char alignY) => Natives.xB8A850F20A067EB6((int)alignX, (int)alignY);
        /// <summary>
        /// Sets the draw offset/calculated size for SET_SCRIPT_GFX_ALIGN. 
        /// If using any alignment other than left/top, the game expects the width/height to be configured 
        /// using this native in order to get a proper starting position for the draw command.
        /// </summary>
        /// <param name="x">The X offset for the item to be drawn.</param>
        /// <param name="y">The Y offset for the item to be drawn.</param>
        /// <param name="w">The width of the item to be drawn.</param>
        /// <param name="h">The height of the item to be drawn.</param>
        public static void SetScriptGfxAlignParams(float x, float y, float w, float h) => Natives.xF5A2C681787E579D(x, y, w, h);
        public static void ResetScriptGfxAlign() => Natives.xE3A3DB414A373DAB();

        public static Vector3 GetTextureResolution(string textureDict, string textureName) => Natives.x35736EE65BD00C11<Vector3>(textureDict, textureName);
    }
}
