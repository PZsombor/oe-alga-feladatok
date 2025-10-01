using System;
using System.Collections;
using System.Collections.Generic;

namespace OE.ALGA.Paradigmak
{
    public class FeltetelesFeladatTarolo<T> : FeladatTarolo<T> where T : IVegrehajthato
    {
        public T[] tarolo;
        public int n;

        public FeltetelesFeladatTarolo(int meret) : base(meret)
        {
            tarolo = new T[meret];
        }

        public void FeltetelesVegrehajtas(Func<T,bool> feltetel)
        {
            for (int i = 0; i < tarolo.Length-1; i++)
            {
                if (feltetel(tarolo[i]))
                {
                    (tarolo[i] as IVegrehajthato).Vegrehajtas();
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new FeltetelesFeladatTaroloBejaro<T>(tarolo, n);
        }
    }

    public class FeltetelesFeladatTaroloBejaro<T> where T : IEnumerator<T>
    {
        T[] tarolo;
        int n;
        int aktualisIndex = -1;
        Func<T,bool> feltetel;

        public FeltetelesFeladatTaroloBejaro(T[] tarolo, int n, Func<T,bool> feltetel)
        {
            this.tarolo = tarolo;
            this.n = n;
            this.feltetel = feltetel;
        }

        public T Current
        {
            get
            {
                return tarolo[aktualisIndex];
            }
        }


        public bool MoveNext()
        {
            aktualisIndex++;
            return aktualisIndex < n;
        }

        public void Reset()
        {
            aktualisIndex = -1;
        }
    }
}
