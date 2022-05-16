using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnsonMath
{

    public struct Vector2
    {

        public Vector2(float _x = 0, float _y = 0)
        {
            x = _x;
            y = _y;
        }
         public static Vector2 operator +(Vector2 vec1, Vector2 vec2)
        {
            Vector2 temp = new Vector2();

            temp.x = vec1.x + vec2.x;
            temp.y = vec1.y + vec2.y;
            
            return temp;
        }

        public static Vector2 operator -(Vector2 vec1, Vector2 vec2)
        {
            //Vec2 to Vec1
            Vector2 temp = Vector2.Zero();

            //만들어야함.


            return temp;
        }

        public float x;
        public float y;

        //public float magnitude;

        public static Vector2 Zero()
        {
            return new Vector2(0f, 0f);
        }

        


        
    }


}
