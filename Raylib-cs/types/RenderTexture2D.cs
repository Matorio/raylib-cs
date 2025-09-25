using System.Runtime.InteropServices;
using System.Numerics;

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

    public static RenderTexture2D Load(Vector2 size)
    {
        return Raylib.LoadRenderTexture((int)size.X, (int)size.Y);
    }

    public readonly void Draw(int x, int y)
    {
        Draw(x, y, Color.White);
    }

    public readonly void Draw(int x, int y, Color color)
    {
        Draw(new Vector2(x, y), color);
    }

    public readonly void Draw(Vector2 position)
    {
        Draw(position, Vector2.Zero, 0.0f, Color.White);
    }

    public readonly void Draw(Vector2 position, Color color)
    {
        Draw(position, Vector2.Zero, 0.0f, color);
    }

    public readonly void Draw(Vector2 position, Vector2 origin)
    {
        Draw(position, origin, 0.0f, Color.White);
    }

    public readonly void Draw(Vector2 position, Vector2 origin, Color color)
    {
        Draw(position, origin, 0.0f, color);
    }

    public readonly void Draw(Vector2 position, Vector2 origin, float rotation, Color color)
    {
        Rectangle source = new Rectangle(0, 0, Texture.Width, -Texture.Height);
        Rectangle dest = new Rectangle(position, Texture.Width, Texture.Height);
        Raylib.DrawTexturePro(Texture, source, dest, origin, rotation, color);
    }

    public readonly void Draw(Rectangle target)
    {
        Draw(target, Vector2.Zero, 0.0f, Color.White);
    }

    public readonly void Draw(Rectangle target, Vector2 origin)
    {
        Draw(target, origin, 0.0f, Color.White);
    }

    public readonly void Draw(Rectangle target, Color color)
    {
        Draw(target, Vector2.Zero, 0.0f, color);
    }

    public readonly void Draw(Rectangle target, Vector2 origin, Color color)
    {
        Draw(target, origin, 0.0f, color);
    }

    public readonly void Draw(Rectangle target, Vector2 origin, float rotation)
    {
        Draw(target, origin, rotation, Color.White);
    }

    public readonly void Draw(Rectangle target, Vector2 origin, float rotation, Color color)
    {
        Rectangle source = new Rectangle(0, 0, Texture.Width, -Texture.Height);
        Raylib.DrawTexturePro(Texture, source, target, origin, rotation, color);
    }

    public readonly void Unload()
    {
        Raylib.UnloadRenderTexture(this);
    }
}
