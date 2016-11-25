﻿using SharpGL;
using SharpGL.VertexBuffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PseudoGameEngine.math;

namespace PseudoGameEngine.graphics
{
    public class BatchRenderer2D : Renderer2D
    {
        readonly static uint SHADER_VERTEX_INDEX = 0;
        readonly static uint SHADER_UV_INDEX = 1;
        readonly static uint SHADER_COLOR_INDEX = 1;

        readonly static int SHADER_VERTEX_SIZE = (3 * 4);
        readonly static int SHADER_UV_SIZE = (2 * 4);
        readonly static int SHADER_COLOR_SIZE = (1 * 4);

        readonly static int RENDERER_MAX_SPRITES = 10000;
        readonly static int RENDERER_VERTEX_SIZE = Marshal.SizeOf<VertexData>();//SHADER_VERTEX_SIZE + SHADER_UV_SIZE + SHADER_COLOR_SIZE;
        readonly static int RENDERER_SPRITE_SIZE = RENDERER_VERTEX_SIZE * 4;
        readonly static int RENDERER_BUFFER_SIZE = RENDERER_SPRITE_SIZE * RENDERER_MAX_SPRITES;
        readonly static int RENDERER_INDICES_SIZE = RENDERER_MAX_SPRITES * 6;

        private uint[] _VAO = new uint[2];
        private uint _VBO;
        private indexbuffer _indexbuffer;
        private int _IndexCount;
        //private VertexData[] _Buffer = new VertexData[4];
        //private IntPtr mapbuffer;
        
        private unsafe VertexData* _Buffer; 

        OpenGL gl = new OpenGL();

        public BatchRenderer2D()
        {
            init();
        }
        
        private void init()
        {
            gl.GenVertexArrays(1, _VAO);
            
            uint[] bufferID = new uint[2];            
            gl.GenBuffers(1, bufferID);
            _VBO = bufferID[0];

            gl.BindVertexArray(_VAO[0]);
                                    
            gl.BindBuffer(OpenGL.GL_ARRAY_BUFFER,_VBO);            
            gl.BufferData(OpenGL.GL_ARRAY_BUFFER, RENDERER_BUFFER_SIZE, IntPtr.Zero, OpenGL.GL_DYNAMIC_DRAW);
              
            gl.EnableVertexAttribArray(SHADER_VERTEX_INDEX);
           // gl.EnableVertexAttribArray(SHADER_UV_INDEX);
            gl.EnableVertexAttribArray(SHADER_COLOR_INDEX);
              
            gl.VertexAttribPointer(SHADER_VERTEX_INDEX, 3, OpenGL.GL_FLOAT, false,  RENDERER_VERTEX_SIZE, IntPtr.Zero);
           
                 // gl.VertexAttribPointer(SHADER_UV_INDEX, 2, OpenGL.GL_FLOAT, false, RENDERER_VERTEX_SIZE,IntPtr.Zero )// new IntPtr(SHADER_VERTEX_SIZE));


            gl.VertexAttribPointer(SHADER_COLOR_INDEX, 4, OpenGL.GL_FLOAT /*OpenGL.GL_UNSIGNED_BYTE*/, true, RENDERER_VERTEX_SIZE, new IntPtr(3 * Marshal.SizeOf<float>()));//new IntPtr(SHADER_VERTEX_SIZE + SHADER_UV_SIZE));
           
            gl.BindBuffer(OpenGL.GL_ARRAY_BUFFER, 0);

            ushort[] indices = new ushort[RENDERER_INDICES_SIZE];

            ushort offset = 0;
            for (int i = 0; i < RENDERER_INDICES_SIZE; i += 6)
            {
                indices[i + 0] = (ushort)(offset + 0);
                indices[i + 1] = (ushort)(offset + 1);
                indices[i + 2] = (ushort)(offset + 2);
                                                    
                indices[i + 3] = (ushort)(offset + 2);
                indices[i + 4] = (ushort)(offset + 3);
                indices[i + 5] = (ushort)(offset + 0);

                offset += 4;
            }

            _indexbuffer = new indexbuffer(indices, (uint)RENDERER_INDICES_SIZE);

            gl.BindVertexArray(0);
        }

        public void begin()
        {
            gl.BindBuffer(OpenGL.GL_ARRAY_BUFFER, _VBO);
            // _Buffer = (VertexData[])Marshal.PtrToStructure(gl.MapBuffer(OpenGL.GL_ARRAY_BUFFER, OpenGL.GL_WRITE_ONLY), typeof(VertexData[]));
            unsafe
            {
                _Buffer = (VertexData*)gl.MapBuffer(OpenGL.GL_ARRAY_BUFFER, OpenGL.GL_WRITE_ONLY).ToPointer();
            }

            //mapbuffer = gl.MapBuffer(OpenGL.GL_ARRAY_BUFFER, OpenGL.GL_WRITE_ONLY);


            //float[] array = new float[3];      
            //Marshal.Copy(p, array, 0, Marshal.SizeOf(p));
            //_Buffer = new buffer(array,1,1);
        }


        public override void submit(Renderable2d renderable)
        {
            Vector3 position = renderable.GetPosition();
            Vector2 size = renderable.GetSize();
            Vector4 color = renderable.GetColor();
            //List<vec2> uv = renderable.getUV();

            unsafe
            {
                _Buffer->vertex = position;
                _Buffer->color = color;
                _Buffer++;
                _Buffer->vertex = new Vector3(position.X, position.Y + size.Y, position.Z);
                _Buffer->color = color;
                _Buffer++;
                _Buffer->vertex = new Vector3(position.X + size.X, position.Y + size.Y, position.Z);
                _Buffer->color = color;
                _Buffer++;
                _Buffer->vertex = new Vector3(position.X + size.X, position.Y, position.Z);
                _Buffer->color = color;
                _Buffer++;
              }
                //_Buffer[0].vertex = position;
                //_Buffer[0].color = color;

                //_Buffer[1].vertex = new Vector3(position.X, position.Y + size.Y, position.Z);
                //_Buffer[1].color = color;

                //_Buffer[2].vertex = new Vector3(position.X + size.X, position.Y + size.Y, position.Z);
                //_Buffer[2].color = color;

                //_Buffer[3].vertex = new Vector3(position.X + size.X, position.Y, position.Z);
                //_Buffer[3].color = color;

                //IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf<VertexData>() * 4);

                //IntPtr result = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VertexData)) * _Buffer.Length);
                //IntPtr c = new IntPtr(result.ToInt32());
                //IntPtr b = new IntPtr(c.ToInt32());
                //for (int j = 0; j < _Buffer.Length;j++)
                //{
                //    Marshal.StructureToPtr(_Buffer[j], c, false);
                //    c = new IntPtr(c.ToInt32() + Marshal.SizeOf(typeof(VertexData)));               
                //}

                //try{Marshal.WriteIntPtr(mapbuffer, c);}
                //catch (Exception e) { delete(); }

                _IndexCount += 6;

            //int r = (int)(color.x * 255);
            //int g = (int)(color.y * 255);
            //int b = (int)(color.z * 255);
            //int a = (int)(color.w * 255);

            //float c = Float.intBitsToFloat((r << 0) | (g << 8) | (b << 16) | (a << 24));

            //m_Buffer.put(position.x).put(position.y).put(position.z);
            //m_Buffer.put(uv.get(0).x).put(uv.get(0).y);
            //m_Buffer.put(c);

            //m_Buffer.put(position.x).put(position.y + size.y).put(position.z);
            //m_Buffer.put(uv.get(1).x).put(uv.get(1).y);
            //m_Buffer.put(c);

            //m_Buffer.put(position.x + size.x).put(position.y + size.y).put(position.z);
            //m_Buffer.put(uv.get(2).x).put(uv.get(2).y);
            //m_Buffer.put(c);

            //m_Buffer.put(position.x + size.x).put(position.y).put(position.z);
            //m_Buffer.put(uv.get(3).x).put(uv.get(3).y);
            //m_Buffer.put(c);

            //m_IndexCount += 6;
        }


        public void end()
        {
            gl.UnmapBuffer(OpenGL.GL_ARRAY_BUFFER);
            gl.BindBuffer(OpenGL.GL_ARRAY_BUFFER, 0);
        }


        public override void flush()
        {
            gl.BindVertexArray(_VAO[0]);
            _indexbuffer.bind();

            gl.DrawElements(OpenGL.GL_TRIANGLES, _IndexCount, OpenGL.GL_UNSIGNED_SHORT, IntPtr.Zero);

            _indexbuffer.unbind();
            gl.BindVertexArray(0);

            _IndexCount = 0;
        }

        public void delete()
        {
            uint[] vbo = { _VBO, 0 };
            gl.DeleteBuffers(0, vbo);
        }

    }
}