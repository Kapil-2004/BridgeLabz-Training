using System;

namespace RailwayReservationSystem
{
    class ReservationMain
    {
        public void Start()
        {
            ReservationMenu Menu = new ReservationMenu();
            Menu.ShowMenu();
        }
    }
}