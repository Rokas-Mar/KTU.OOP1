using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2.Register.Individual
{
    internal class FlatList
    {
        private List<Flat> AllFlats;

        public FlatList()
        {
            AllFlats = new List<Flat>();
        }

        public FlatList(List<Flat> allFlats)
        {
            AllFlats = allFlats;
            foreach(Flat flat in allFlats)
            {
                AllFlats.Add(flat);
            }
        }

        public bool Contains(Flat flats)
        {
            return AllFlats.Contains(flats);
        }

        public void Add(Flat flat)
        {
            AllFlats.Add(flat);
        }

        public int FlatCount()
        {
            return this.AllFlats.Count();
        }

        public Flat GetIndexedElement(int index)
        {
            Flat flat = AllFlats[index];
            return flat;
        }

        public FlatList FindRequestedFlats(int roomCount, int floorStart, int floorEnd, double price)
        {
            FlatList Filtered = new FlatList();
            for(int i = 0; i < AllFlats.Count; i++)
            {
                if (AllFlats[i].RoomCount == roomCount &&
                    AllFlats[i].Floor >= floorStart &&
                    AllFlats[i].Floor <= floorEnd &&
                    AllFlats[i].SellPrice <= price)
                {
                    Flat flat = AllFlats[i];
                    Filtered.Add(flat);
                }
            }

            return Filtered;
        }
    }
}
