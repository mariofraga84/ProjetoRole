using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Web;

namespace ProjetoRole.Uteis
{
    public class Geo
    {    
        public double getDistancia(double origem_lat, double origem_lng, double dest_lat, double dest_lng)
        {
            GeoCoordinate geo = new GeoCoordinate(origem_lat, origem_lng);
            double dist = geo.GetDistanceTo(new GeoCoordinate(dest_lat, dest_lng)) / 1000;
            return Math.Round(dist, 1);
        }
    }
}