using System.Runtime.InteropServices;

namespace Raylib_cs;

/// <summary>
/// RenderTexture2D type, for texture rendering
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct RenderTexture2D : IValidable
{
    /// <summary>
    /// OpenGL Framebuffer Object (FBO) id
    /// </summary>
    public uint Id;

    /// <summary>
    ///  Color buffer attachment texture
    /// </summary>
    public Texture2D Texture;

    /// <summary>
    /// Depth buffer attachment texture
    /// </summary>
    public Texture2D Depth;

    public readonly CBool IsValid => Raylib.IsRenderTextureValid(this);

    public static RenderTexture2D Load(int width, int height)
    {
        return Raylib.LoadRenderTexture(width, height);
    }

    public static RenderTexture2D Load(System.Numerics.Vector2 size)
    {
        return Raylib.LoadRenderTexture((int)size.X, (int)size.Y);
    }

    public void Unload()
    {
        Raylib.UnloadRenderTexture(this);
    }
}
