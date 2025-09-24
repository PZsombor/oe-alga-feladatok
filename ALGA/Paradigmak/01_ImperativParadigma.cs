using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OE.ALGA.Paradigmak
{
    // 1. heti labor feladat - Tesztek: 01_ImperativParadigmaTesztek.cs
    public interface IVegrehajthato
    {
        public void Vegrehajtas();
    }

    public interface IFuggo
    {
        public bool FuggosegTeljesul { get; }
    }

    public interface IEnumerable<T>
    {
        public IEnumerator GetEnumerator();
    }

    public interface IEnumerator<T>
    {
        public T Aktualis { get; }
        public void Current();
        public bool MoveNext();
    }

    public class TaroloMegteltKivetel : Exception
    {
        public TaroloMegteltKivetel()
        {
        }

        public TaroloMegteltKivetel(string? message) : base(message)
        {
        }

        public TaroloMegteltKivetel(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }

    public class FeladatTarolo<T> where T : IVegrehajthato, IEnumerable
    {
        public T[] tarolo;
        public int n;

        public FeladatTarolo(int meret)
        {
            tarolo = new T[meret];
            n = 0;
        }
        
        public void Felvesz(T elem)
        {

            for (int i = 0; i < tarolo.Length-1; i++)
            {
                if (tarolo[i] == null)
                {
                    tarolo[i] = elem;
                }
                else throw new TaroloMegteltKivetel(":D");
            }
        }

        public void MindentVegrehajt()
        {
            for(int i = 0;i < tarolo.Length - 1; i++)
            {
                if (tarolo[i] != null)
                {
                    tarolo[i].Vegrehajtas();
                }
            }
        }

        public FeladatTaroloBejaro<T> BejaroLetrehozas()
        {
            for (int i = 0; i < tarolo.Length-1; i++)
            {
                //return 
            }
            throw new Exception("gatya");
        }
    }

    public class FuggoFeladatTarolo<T> : FeladatTarolo<T> where T : IVegrehajthato, IFuggo, IEnumerable
    {
        public FuggoFeladatTarolo(int meret) : base(meret)
        {
        }

        public void MindentVegrehajt(T elem)
        {
            for (int i = 0; i < tarolo.Length-1; i++)
            {
                if (tarolo[i].FuggosegTeljesul)
                {
                    (tarolo[i] as IVegrehajthato).Vegrehajtas();
                }
            }
        }
    }

    public class FeladatTaroloBejaro<T> where T : IVegrehajthato, IEnumerator
    {
        public T[] tarolo;
        public int n;
        public int aktualisIndex;
        public T Aktualis { get; }

        public FeladatTaroloBejaro(T[] tarolo, int n)
        {
            this.tarolo = tarolo;
            this.n = n;
        }

        public void Current()
        {
            
        }

        public bool MoveNext()
        {
            return true;
        }
    }
}

