﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiControllers.Models
{
    public class MemoryRepository : IRepository
    {
        private Dictionary<int, Reservation> items;

        public MemoryRepository()
        {
            items = new Dictionary<int, Reservation>();
            new List<Reservation>
            {
                new Reservation{ClientName= "Alice", Location="Board room"},
                new Reservation{ClientName="Bob", Location="Lecture Hall" },
                new Reservation{ClientName = "Joe", Location="Meeting room" }
            }.ForEach(r => AddReservation(r));
        }
        public Reservation this[int id]=> items.ContainsKey(id)?items[id] :null;
        public IEnumerable<Reservation> Reservations => items.Values;
        public Reservation AddReservation(Reservation r)
        {
            if (r.ReservationId == 0)
            {
                int key = items.Count;
                while (items.ContainsKey(key))
                {
                    key++;
                };
                r.ReservationId = key;
            }
            items[r.ReservationId]= r;
            return r;
        }
        public void DeleteReservation(int id)
        {
            items.Remove(id);
        }
        public Reservation UpdateReservation(Reservation reservation)
        {
            return AddReservation(reservation);
        }
    }
}
