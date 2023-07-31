using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20230725
{
    class MeshRenderer : Component
    {
        public byte R;
        public byte G;
        public byte B;
        public byte A;

        public string textureName;

        public int SpirteSize = 40;

        IntPtr mySurface;
        IntPtr myTexture;

        protected MeshFilter meshFilter;
        public MeshRenderer()
        {

        }
        public MeshRenderer(byte inR, byte inG, byte inB, byte inA)
        {
            R = inR;
            G = inG;
            B = inB;
            A = inA;
        }

        public MeshRenderer(byte inR, byte inG, byte inB, byte inA, string inTextureName)
        {
            R = inR;
            G = inG;
            B = inB;
            A = inA;
            textureName = inTextureName;

            mySurface = SDL.SDL_LoadBMP("Data/"+textureName);
            myTexture = SDL.SDL_CreateTextureFromSurface(Engine.GetInstance().myRenderer, mySurface);
        }
        ~MeshRenderer() { }

        public override void Start()
        {
            foreach (var component in gameObject.components)
            {
                if (component is MeshFilter)
                {
                    meshFilter = (component as MeshFilter);
                }
            }
        }

        public virtual void Render()
        {
            //Console.SetCursorPosition(transform.x, transform.y);
            //Console.WriteLine(meshFilter.Shape);

            //Fill Rect
            //SDL.SDL_Rect destination = new SDL.SDL_Rect();
            //destination.x = transform.x * SpirteSize;
            //destination.y = transform.y * SpirteSize;
            //destination.w = SpirteSize;
            //destination.h = SpirteSize;
            //SDL.SDL_SetRenderDrawColor(Engine.GetInstance().myRenderer, R, G, B, A);
            //SDL.SDL_RenderFillRect(Engine.GetInstance().myRenderer, ref destination);
            unsafe //c언어 ,c++
            {
                SDL.SDL_Rect source = new SDL.SDL_Rect();
                SDL.SDL_Surface* surface = (SDL.SDL_Surface*)mySurface;

                source.x = 0;
                source.y = 0;
                source.w = surface->w;
                source.h = surface->h;

                SDL.SDL_Rect destination = new SDL.SDL_Rect();
                destination.x = transform.x * SpirteSize;
                destination.y = transform.y * SpirteSize;
                destination.w = SpirteSize;
                destination.h = SpirteSize;

                SDL.SDL_RenderCopy(Engine.GetInstance().myRenderer,
                    myTexture,
                    ref source,
                    ref destination);
            }


        }
    }
}
