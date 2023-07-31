using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
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
         
        //SDL.SDL_Color colorKey;
        public bool isSprite;

        public string textureName;

        public int SpirteSize = 40;

        IntPtr mySurface;
        IntPtr myTexture;

        protected int index = 0;

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

        public MeshRenderer(byte inR, byte inG, byte inB, byte inA, string inTextureName, bool inIsSpirte = false) 
        {
            R = inR;
            G = inG;
            B = inB;
            A = inA;
            textureName = inTextureName;
            isSprite = inIsSpirte;

            string projectFolder = System.IO.Directory.GetParent(System.Environment.CurrentDirectory).Parent.FullName;
            unsafe
            {
                mySurface = SDL.SDL_LoadBMP(projectFolder + "/Data/" + textureName);
                SDL.SDL_Surface* surface = ( SDL.SDL_Surface*)mySurface;
                if (!isSprite)
                {
                    SDL.SDL_SetColorKey(mySurface, 1,
                        SDL.SDL_MapRGB(surface->format, 255, 255, 255));
                }
                else
                {
                    SDL.SDL_SetColorKey(mySurface, 1,
                        SDL.SDL_MapRGB(surface->format, 255, 0, 255));
                }
                myTexture = SDL.SDL_CreateTextureFromSurface(Engine.GetInstance().myRenderer, mySurface);
            }
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
                if (!isSprite)
                {
                    source.x = 0;
                    source.y = 0;
                    source.w = surface->w;
                    source.h = surface->h;
                }
                else
                {
                    int sizeX = surface->w / 5;
                    int sizeY = surface->h / 5;
                    source.x = index * sizeX;
                    source.y = 0 * sizeY;
                    source.w = sizeX;
                    source.h = sizeY;

                    index++;
                    if (index > 5)
                    {
                        index = 0;
                    }

                }

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

            //Animation


        }
    }
}
