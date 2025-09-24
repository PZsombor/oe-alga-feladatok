using System;
using System.Collections;
using System.Collections.Generic;

namespace OE.ALGA.Paradigmak
{
    public class FeltetelesFeladatTarolo<T> : FeladatTarolo<T> where T : IVegrehajthato, IEnumerable
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
                if (tarolo[i].FuggosegTeljesul)
                {
                    (tarolo[i] as IVegrehajthato).Vegrehajtas();
                }
            }
        }

        public void Felvesz(T elem)
        {

        }

        public void MindentVegrahajt()
        {

        }

        public T FeladatTaroloBejaro()
        {
            
        }
    }
}
