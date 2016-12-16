using SharpGL;

namespace PseudoGameEngine
{
    static public class Sysinfo
    {
        static OpenGL gl = new OpenGL();
        static public string OpenGLVersion
        {
            get { return gl.GetString(OpenGL.GL_VERSION); }
        }
        static public string Render
        {
            get { return gl.GetString(OpenGL.GL_RENDERER); }
        }
        static public string Vendor
        {
            get { return gl.GetString(OpenGL.GL_VENDOR); }
        }
        static public string ShadingLanguageVersion
        {
            get { return gl.GetString(OpenGL.GL_SHADING_LANGUAGE_VERSION​); }
        }

    }
}
