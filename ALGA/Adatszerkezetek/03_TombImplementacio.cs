using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OE.ALGA.Adatszerkezetek
{
    // 3. heti labor feladat - Tesztek: 03_TombImplementacioTesztek.cs
    public class TombVerem<T> where T : Verem<T>
    {
        public T[] E;
        public int n = 0;
        public bool Ures 
        {
            get
            {
                if (E[0] == null )
                {
                    return true;
                }
                return false;
            }
        }

        public TombVerem(int meret)
        {
            E = new T[meret];
        }

        public void Verembe(T ertek)
        {
            if (n < E.Length)
            {
                n++;
                E[n] = ertek;
            }
            else throw new NincsHelyKivetel();
        }

        public T Verembol()
        {
            if (!Ures)
            {
                n = n - 1;
                return E[n];
            }
            else throw new NincsElemKivetel();
        }

        public T Felso()
        {
            if (!Ures)
            {
                return E[n];
            }
            else throw new NincsElemKivetel();
        }

        public void Felszabadit()
        {
            while (!Ures)
            {
                Verembol();
            }
        }
    }

    public class TombSor<T> where T : Sor<T>
    {

    }
}
