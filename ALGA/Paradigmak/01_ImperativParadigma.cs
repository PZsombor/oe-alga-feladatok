using System;
using System.Collections;
using System.Collections.Generic;

namespace OE.ALGA.Paradigmak
{
    // 1. Interfész IVégrehajtható
    public interface IVegrehajthato
    {
        void Vegrehajtas();
    }

    // 3. Interfész IFüggő
    public interface IFuggo
    {
        bool FuggosegTeljesul { get; }
    }

    // 2.c Kivétel osztály: TárolóMegteltKivétel
    public class TaroloMegteltKivetel : Exception
    {
        public TaroloMegteltKivetel() : base("A tároló megtelt.") { }
    }

    // 2. Generikus FeladatTároló osztály
    public class FeladatTarolo<T> : IEnumerable<T> where T : IVegrehajthato
    {
        protected T[] tarolo;
        protected int n;

        public FeladatTarolo(int meret)
        {
            tarolo = new T[meret];
            n = 0;
        }

        public void Felvesz(T elem)
        {
            if (n < tarolo.Length)
            {
                tarolo[n++] = elem;
            }
            else
            {
                throw new TaroloMegteltKivetel();
            }
        }

        public virtual void MindentVegrehajt()
        {
            for (int i = 0; i < n; i++)
            {
                tarolo[i].Vegrehajtas();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new FeladatTaroloBejaro<T>(tarolo, n);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    // 4. FüggőFeladatTároló osztály
    public class FuggoFeladatTarolo<T> : FeladatTarolo<T> where T : IVegrehajthato, IFuggo
    {
        public FuggoFeladatTarolo(int meret) : base(meret) { }

        public override void MindentVegrehajt()
        {
            for (int i = 0; i < n; i++)
            {
                if (tarolo[i].FuggosegTeljesul)
                {
                    tarolo[i].Vegrehajtas();
                }
            }
        }
    }

    // 5. Bejáró osztály
    public class FeladatTaroloBejaro<T> : IEnumerator<T>
    {
        private readonly T[] tarolo;
        private readonly int n;
        private int aktualisIndex;

        public FeladatTaroloBejaro(T[] tarolo, int n)
        {
            this.tarolo = tarolo;
            this.n = n;
        }

        public T Current
        {
            get
            {
                if (aktualisIndex < 0 || aktualisIndex >= n)
                    throw new InvalidOperationException();
                return tarolo[aktualisIndex];
            }
        }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            aktualisIndex++;
            return aktualisIndex < n;
        }

        public void Reset()
        {
            aktualisIndex = -1;
        }

        public void Dispose() { }
    }
}